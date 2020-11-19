using System;
using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/

    /// <summary>
    /// Handler para filtrar la búsqueda.
    /// </summary>
    public class FilterHandler : AbstractHandler<IMessage>
    {
        public FilterHandler(FilterCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {

            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= data.User.Accounts.Count)
                {
                    data.Temp.Add("account", data.User.Accounts[index - 1]);
                    data.Channel.SendMessage(request.Id, "Seleccione que tipo de filtro, para aplicar los filtros selecciones Buscar:\n1 - Buscar\n2 - Tipo\n3 - Rubro\n4 - Fecha");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor igual al índice indicado.");
                    data.Channel.SendMessage(request.Id, "Seleccione una cuenta para ver el historial:\n" + data.User.ShowAccountList());
                }
                return;
            }

            if (!data.Temp.ContainsKey("type") && !data.Temp.ContainsKey("item") && !data.Temp.ContainsKey("date"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= 4)
                {
                    var account = data.GetDictionaryValue<Account>("account");

                    switch (index)
                    {
                        // buscar
                        case 1:
                            data.Channel.SendMessage(request.Id, "Filtrando...");
                            var filePath = Search.Instance.ApplyFilter(request.Id, account.History);
                            data.Channel.SendFile(request.Id, filePath);
                            data.ClearOperation();
                            return;

                        // tipo
                        case 2:
                            data.Temp.Add("type", string.Empty);
                            data.Channel.SendMessage(request.Id, "Seleccione el tipo por el cual desea filtrar:\n1 - Ingreso\n2 - Egreso");
                            return;

                        // rubro
                        case 3:
                            data.Temp.Add("item", string.Empty);
                            data.Channel.SendMessage(request.Id, "Seleccione el rubro por el cual desea filtrar o ingrese una palabra:\n_1" + data.User.ShowItemList());
                            return;

                        // fecha
                        case 4:
                            data.Temp.Add("date", string.Empty);
                            data.Channel.SendMessage(request.Id, "Seleccione una opción:\n1 - A partir de una fecha\n2 - En un rango de fechas");
                            return;

                        default:
                            data.Channel.SendMessage(request.Id, "Debe ingresar un valor igual al índice indicado.");
                            data.Channel.SendMessage(request.Id, "Seleccione que tipo de filtro, para aplicar los filtros selecciones Buscar:\n1 - Buscar\n2 - Tipo\n3 - Rubro\n4 - Fecha");
                            break;
                    }
                }
            }

            if (data.Temp.ContainsKey("type") && data.GetDictionaryValue<string>("type") == string.Empty)
            {
                if (request.Text == "1" || request.Text == "2")
                {
                    var type = request.Text == "1" ? "income" : "outcome";
                    data.Filters.Add(new TransactionTypeFilter(type));
                    System.Console.WriteLine(data.Filters.Count);
                    data.Temp.Remove("type");
                    data.Channel.SendMessage(request.Id, "Seleccione que tipo de filtro, para aplicar los filtros selecciones Buscar:\n1 - Buscar\n2 - Tipo\n3 - Rubro\n4 - Fecha");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe seleccionar una de las opciones indicadas.");
                    data.Channel.SendMessage(request.Id, "Seleccione el tipo por el cual desea filtrar:\n1 - Ingreso\n2 - Egreso");
                }
            }

            else if (data.Temp.ContainsKey("item") && data.GetDictionaryValue<string>("item") == string.Empty)
            {
                int index;
                string item;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= data.User.OutcomeList.Count)
                {
                    item = data.User.OutcomeList[index - 1];
                }
                else
                {
                    item = request.Text;
                }

                data.Filters.Add(new TransactionItemFilter(item));
                data.Temp.Remove("item");
                data.Channel.SendMessage(request.Id, "Seleccione que tipo de filtro, para aplicar los filtros selecciones Buscar:\n1 - Buscar\n2 - Tipo\n3 - Rubro\n4 - Fecha");
            }

            else if (data.Temp.ContainsKey("date"))
            {
                if (data.GetDictionaryValue<string>("date") == string.Empty)
                {
                    if (request.Text == "1")
                    {
                        data.Channel.SendMessage(request.Id, "Ingrese una fecha en el formato dd/mm/aaaa:");
                        data.Temp["date"] = "from";
                    }
                    else if (request.Text == "2")
                    {
                        data.Channel.SendMessage(request.Id, "Ingrese la primer fecha en el formato dd/mm/aaaa:");
                        data.Temp["date"] = "range";
                    }
                }

                else if (data.GetDictionaryValue<string>("date") != string.Empty)
                {
                    var dateSplit = request.Text.Split("/");
                    var dateInt = new List<int>();
                    DateTime date = DateTime.Now;

                    foreach (var item in dateSplit)
                    {
                        int number;
                        if (Int32.TryParse(item, out number))
                        {
                            dateInt.Add(number);
                        }
                        else
                        {
                            data.Channel.SendMessage(request.Id, "Debe ingresar una fecha en el formato dd/mm/aaaa:");
                        }
                    }

                    if (dateInt.Count == 3)
                    {
                        try
                        {
                            date = new DateTime(dateInt[0], dateInt[1], dateInt[2]);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            data.Channel.SendMessage(request.Id, "Debe ingresar una fecha en el formato dd/mm/aaaa:");
                        }
                    }

                    if (data.GetDictionaryValue<string>("date") == "from")
                    {
                        data.Filters.Add(new TransactionDateFilter(date));
                        data.Temp.Remove("date");
                        data.Channel.SendMessage(request.Id, "Seleccione que tipo de filtro, para aplicar los filtros selecciones Buscar:\n1 - Buscar\n2 - Tipo\n3 - Rubro\n4 - Fecha");
                    }
                    else if (data.GetDictionaryValue<string>("date") == "range")
                    {
                        data.Temp.Add("dateFrom", date);
                        data.Temp["date"] = "rangeTo";
                        data.Channel.SendMessage(request.Id, "Ingrese la segunda fecha en el formato dd/mm/aaaa:");
                    }
                    else if (data.GetDictionaryValue<string>("date") == "rangeTo")
                    {
                        var dateFrom = data.GetDictionaryValue<DateTime>("dateFrom");
                        data.Filters.Add(new TransactionDateFromToFilter(dateFrom, date));
                        data.Temp.Remove("date");
                        data.Temp.Remove("dateFrom");
                    }
                }
            }
        }
    }
}