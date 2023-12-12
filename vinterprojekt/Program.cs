// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);



List<Rectangle> wall = new();


wall.Add(new Rectangle(300, 100, 60, 20));
wall.Add(new Rectangle(320, 0, 16, 20));
wall.Add(new Rectangle(150, 0, 32, 128));
wall.Add(new Rectangle(123, 0, 1800, 20));

Rectangle playerRect = new Rectangle(50, 50, 100, 100);
Rectangle enemyRect = new Rectangle(1000, 100, 100, 100);

string scene;
scene = "game";
scene = "start";

while (!Raylib.WindowShouldClose())
{




  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.WHITE);

  Rectangle overlap = Raylib.GetCollisionRec(playerRect, enemyRect);

  Raylib.DrawRectangleRec(playerRect, Color.RED);
  Raylib.DrawRectangleRec(enemyRect, Color.BLUE);
  Raylib.DrawRectangleRec(overlap, Color.ORANGE);

  if (scene == "start"){

    Console.WriteLine("welcome to the game");

  }

  


  if (scene == "game")
  {

    enemyRect.Y +=1;

    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
      playerRect.X += 5;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
      playerRect.X -= 5;
    }

      if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
      playerRect.Y -= 5;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
      playerRect.Y +=5;
    }
     
 if (playerRect.X < 0 || playerRect.X > 1699) {
 playerRect.X = -1;
  }

if (playerRect.Y < 0  || playerRect.Y > 799) {
playerRect.Y = -1;

  }



/*bool isInAWall = CheckIfWall(playerRect, wall);

  if (isInAWall == true)
    {
    
    }
*/
 /*foreach (Rectangle wall in walls)
   {
    if (Raylib.CheckCollisionRecs(playerRect, wall))
    {
  playerRect.X *= -1;
  playerRect.Y *= -1;

    }
  }*/


  Raylib.EndDrawing();
  }
}