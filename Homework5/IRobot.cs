namespace Homework5
{
    internal interface IRobot
    {
        public string GetInfo();
        public List<string> GetComponents();
        public string GetRobotType() => "I am a simple robot.";
    }
}
