using System;

namespace Bankbot
{
    public class AddItemHandler : AbstractHandler<IMessage>
    {
        public AddItemHandler(AddItemCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (request.Text != string.Empty)
            {
                if (!data.User.ContainsItem(request.Text))
                {
                    data.User.OutcomeList.Add(request.Text);
                    data.Channel.SendMessage(request.Id, "Se ha agregado un nuevo rubro.");
                    data.ClearOperation();
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Ya existe un rubro con este nombre.");
                    data.Channel.SendMessage(request.Id, "Ingrese un nuevo rubro:");
                }
            }
            else
            {
                data.Channel.SendMessage(request.Id, "Debe ingresar un rubro.");
                data.Channel.SendMessage(request.Id, "Ingrese un nuevo rubro:");
            }
        }
    }
}