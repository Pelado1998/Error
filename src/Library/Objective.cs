namespace Bankbot
{
    /*Cumple con SRP y EXPERT ya que es la unica responsabilidad el objetivo y el la mejor encargada
    de manejarlo.*/
    /// <summary>
    /// Crea los objetivos por cuenta del usuario.
    /// </summary>
    public class Objective
    {
        public double Max { get; set; }
        public double Min { get; set; }

        public Objective(double max, double min)
        {
            this.Max = max;
            this.Min = min;
        }
    }
}