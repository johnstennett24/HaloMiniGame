using HaloMiniGame.Game.Casting;

namespace HaloMiniGame.Game.Scripting
{
    public class MoveRacketAction : Action
    {
        public MoveRacketAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MC mC = (MC)cast.GetFirstActor(Constants.MC_GROUP);
            Body body = mC.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            if (x < 0)
            {
                position = new Point(0, position.GetY());
            }
            else if (x > Constants.SCREEN_WIDTH - Constants.MC_WIDTH)
            {
                position = new Point(Constants.SCREEN_WIDTH - Constants.MC_WIDTH, 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}