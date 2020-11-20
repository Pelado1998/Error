namespace Bankbot
{
    public class StartupConfig
    {

        public static void Start()
        {
            TelegramBot.Instance.Start();
            ConsoleBot.Instance.Start();
        }
        public static AbstractHandler<IMessage> HandlerConfig()
        {
            AbstractHandler<IMessage> init = new InitHandler(new InitCondition());
            AbstractHandler<IMessage> abort = new AbortHandler(new AbortCondition());
            AbstractHandler<IMessage> dispatcher = new DispatcherHandler(new DispatcherCondition());
            AbstractHandler<IMessage> convertion = new ConvertionHandler(new ConvertionCondition());
            AbstractHandler<IMessage> login = new LoginHandler(new LoginCondition());
            AbstractHandler<IMessage> createUser = new CreateUserHandler(new CreateUserCondition());
            AbstractHandler<IMessage> transaction = new TransactionHandler(new TransactionCondition());
            AbstractHandler<IMessage> deleteUser = new DeleteUserHandler(new DeleteUserCondition());
            AbstractHandler<IMessage> createAccount = new CreateAccountHandler(new CreateAccountCondition());
            AbstractHandler<IMessage> deleteAccount = new DeleteAccountHandler(new DeleteAccountCondition());
            AbstractHandler<IMessage> filter = new FilterHandler(new FilterCondition());
            AbstractHandler<IMessage> addItem = new AddItemHandler(new AddItemCondition());
            AbstractHandler<IMessage> changeObjective = new ChangeAccountObjectiveHandler(new ChangeAccountObjectiveCondition());
            AbstractHandler<IMessage> addCurrency = new AddCurrencyHandler(new AddCurrencyCondition());
            AbstractHandler<IMessage> balance = new BalanceHandler(new BalanceCondition());
            AbstractHandler<IMessage> def = new DefaultHandler(new DefaultCondition());

            init.Succesor = abort;
            abort.Succesor = dispatcher;
            dispatcher.Succesor = convertion;
            convertion.Succesor = login;
            login.Succesor = createUser;
            createUser.Succesor = transaction;
            transaction.Succesor = deleteUser;
            deleteUser.Succesor = createAccount;
            createAccount.Succesor = deleteAccount;
            deleteAccount.Succesor = filter;
            filter.Succesor = addItem;
            addItem.Succesor = changeObjective;
            changeObjective.Succesor = addCurrency;
            addCurrency.Succesor = balance;
            balance.Succesor = def;

            return init;
        }
    }
}