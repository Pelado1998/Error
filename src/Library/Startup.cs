namespace Bankbot
{
    public class StartupConfig
    {
        public static AbstractHandler<Chats> HandlerConfig()
        {
            AbstractHandler<Chats> init = new Init(new InitCondition());
            AbstractHandler<Chats> mainOptions = new MainOptions(new MainCondition());
            AbstractHandler<Chats> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<Chats> login = new Login(new LoginCondition());
            AbstractHandler<Chats> def = new Default(new DefaultCondition());

            init.Succesor = mainOptions;
            mainOptions.Succesor = createUser;
            createUser.Succesor = login;
            login.Succesor = def;
            return init;
        }
    }
}