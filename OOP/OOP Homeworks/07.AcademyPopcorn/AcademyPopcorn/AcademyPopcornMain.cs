using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }
            for (int i = 20; i < 30; i++)
            {
                ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow + 2, i));
                engine.AddObject(currBlock);
            }
            //for (int i = startCol; i < endCol; i++)
            //{
            //    Block currBlock = new Block(new MatrixCoords(startRow+1, i));
            //    engine.AddObject(currBlock);
            //}

            // TASK 1:
            for (int i = 0; i < WorldRows; i++)
            {
                UnpassableBlock leftSideWall = new UnpassableBlock(new MatrixCoords(i, 0));
                UnpassableBlock rightSideWall = new UnpassableBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(leftSideWall);
                engine.AddObject(rightSideWall);
            }
            for (int i = 1; i < WorldCols - 1; i++)
            {
                UnpassableBlock cellingWall = new UnpassableBlock(new MatrixCoords(0, i));
                engine.AddObject(cellingWall);
            }
            // end of TASK 1

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1), 3); // TASK 7
            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);

            //TrailObject trail = new TrailObject(new MatrixCoords(7, 20), 5); // TASK 5
            //engine.AddObject(trail); // TASK 5

            // TASK 9
            for (int i = 15; i < 20; i++)
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(4, i));
                engine.AddObject(currBlock);
            }

            UnstopableBall usBall = new UnstopableBall(new MatrixCoords(10, 27), new MatrixCoords(-1, -1));
            engine.AddObject(usBall);
            // end of TASK 9

            // TASK 12
            GiftBlock gift = new GiftBlock(new MatrixCoords(6, 25));
            engine.AddObject(gift);
            // end of TASK 12
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 500);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
