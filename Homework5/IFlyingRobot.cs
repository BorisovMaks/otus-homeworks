namespace Homework5
{
    internal interface IFlyingRobot : IRobot
    {
        public new string GetRobotType() => "I am a flying robot.";
    }
}
