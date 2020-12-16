namespace Proyecto
{
    public interface IPowerUp
    {
        int Attack {get;set;}
        int Defense {get;set;}
        int Heal {get;set;}
        string Name {get;set;}
        string Description {get;set;}
    }
}