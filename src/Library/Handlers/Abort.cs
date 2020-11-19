using System;


namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/
    /// <summary>
    /// Handler para cancelar una opción o salir.
    /// </summary>
    public class Exit : AbstractHandler<IMessage>
    {
        public Exit(ExitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            data.ClearOperation();

            data.Channel.SendMessage(request.Id, "Operación cancelada.");
        }
    }
}