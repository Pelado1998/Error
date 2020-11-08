namespace Bankbot
{
    public class StartupConfig
    {
        public static AbstractHandler<Conversation> HandlerConfig()
        {
            AbstractHandler<Conversation> init = new Init(new InitCondition());
            AbstractHandler<Conversation> dispatcher = new Dispatcher(new DispatcherCondition());
            AbstractHandler<Conversation> convertion = new Convertion(new ConvertionCondition());
            AbstractHandler<Conversation> login = new Login(new LoginCondition());
            AbstractHandler<Conversation> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<Conversation> transaction = new TransactionHandler(new TransactionCondition());
            AbstractHandler<Conversation> deleteUser = new DeleteUser(new DeleteUserCondition());
            AbstractHandler<Conversation> createAccount = new CreateAccount(new CreateAccountCondition());
            AbstractHandler<Conversation> deleteAccount = new DeleteAccount(new DeleteAccountCondition());
            AbstractHandler<Conversation> def = new Default(new DefaultCondition());

            init.Succesor = dispatcher;
            dispatcher.Succesor = convertion;
            convertion.Succesor = login;
            login.Succesor = createUser;
            createUser.Succesor = transaction;
            transaction.Succesor = deleteUser;
            deleteUser.Succesor = createAccount;
            createAccount.Succesor = deleteAccount;
            deleteAccount.Succesor = def;

            return init;
        }
    }
}