namespace Singletons
{
    public class GameValues
    {
       
        public int Cash;
        public bool TogglePlayTime;
        private static GameValues GameValuesInstance;

        private GameValues()
        {
            Cash = 4269;
            TogglePlayTime = true;
        }
        

        public static GameValues GetGameValues()
        {
            if (GameValuesInstance == null)
            {
                GameValuesInstance = new GameValues();
            }

            return GameValuesInstance;
        }
    }
    
}
