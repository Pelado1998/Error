namespace Bankbot
{
    public class StartupConfig
    {
        public static AbstractHandler<IMessage> HandlerConfig()
        {
            AbstractHandler<IMessage> init = new Init(new InitCondition());
            AbstractHandler<IMessage> abort = new Exit(new ExitCondition());
            AbstractHandler<IMessage> dispatcher = new Dispatcher(new DispatcherCondition());
            AbstractHandler<IMessage> convertion = new Convertion(new ConvertionCondition());
            AbstractHandler<IMessage> login = new Login(new LoginCondition());
            AbstractHandler<IMessage> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<IMessage> transaction = new MakeTransaction(new TransactionCondition());
            AbstractHandler<IMessage> deleteUser = new DeleteUser(new DeleteUserCondition());
            AbstractHandler<IMessage> createAccount = new CreateAccount(new CreateAccountCondition());
            AbstractHandler<IMessage> deleteAccount = new DeleteAccount(new DeleteAccountCondition());
            AbstractHandler<IMessage> filter = new FilterHandler(new FilterCondition());
            AbstractHandler<IMessage> def = new Default(new DefaultCondition());

            init.Succesor = dispatcher;
            dispatcher.Succesor = abort;
            abort.Succesor = convertion;
            convertion.Succesor = login;
            login.Succesor = createUser;
            createUser.Succesor = transaction;
            transaction.Succesor = deleteUser;
            deleteUser.Succesor = createAccount;
            createAccount.Succesor = deleteAccount;
            deleteAccount.Succesor = filter;
            filter.Succesor = def;

            return init;
        }
    }
}