namespace Bankbot
{
    public class StartupConfig
    {
        public static AbstractHandler<IMessage> HandlerConfig()
        {
            AbstractHandler<IMessage> abort = new Abort(new AbortCondition());
            AbstractHandler<IMessage> commands = new Commands(new CommandsCondition());
            AbstractHandler<IMessage> def = new Default(new DefaultCondition());
            AbstractHandler<IMessage> init = new Init(new InitCondition());
            AbstractHandler<IMessage> dispatcher = new Dispatcher(new DispatcherCondition());
            AbstractHandler<IMessage> convertion = new Convertion(new ConvertionCondition());
            AbstractHandler<IMessage> login = new Login(new LoginCondition());
            AbstractHandler<IMessage> logout = new Logout(new LogoutCondition());
            AbstractHandler<IMessage> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<IMessage> transaction = new MakeTransaction(new TransactionCondition());
            AbstractHandler<IMessage> deleteUser = new DeleteUser(new DeleteUserCondition());
            AbstractHandler<IMessage> createAccount = new CreateAccount(new CreateAccountCondition());
            AbstractHandler<IMessage> deleteAccount = new DeleteAccount(new DeleteAccountCondition());
            
            abort.Succesor = def;
            def.Succesor = dispatcher;
            dispatcher.Succesor = init;
            init.Succesor = convertion;
            convertion.Succesor = login;
            login.Succesor = logout;
            logout.Succesor = createUser;
            createUser.Succesor = transaction;
            transaction.Succesor = deleteUser;
            deleteUser.Succesor = createAccount;
            createAccount.Succesor = deleteAccount;
            deleteAccount.Succesor = commands;
    
            return abort;
        }
    }
}