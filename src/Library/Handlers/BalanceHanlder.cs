using System;

namespace Bankbot
{
    public class BalanceHandler : AbstractHandler<IMessage>
    {
        public BalanceHandler(BalanceCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= data.User.Accounts.Count)
                {
                    var account = data.User.Accounts[index - 1];
                    data.Channel.SendMessage(request.Id, $"El balance de la cuenta es: {account.Currency.CodeISO} {account.Balance}");

                    data.ClearOperation();
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor igual al índice indicado.");
                    data.Channel.SendMessage(request.Id, "Seleccione una cuenta para recibir el balance:\n" + data.User.ShowAccountList());
                }
                return;
            }
        }
    }
}