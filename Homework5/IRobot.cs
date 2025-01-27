namespace Homework5
{
    internal interface IRobot
    {
        public string GetInfo();
        public List<string> GetComponents();
        public string GetRobotType()
        {
            return "I am a simple robot.";
        }
    }
}
