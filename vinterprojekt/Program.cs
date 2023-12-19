// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);



List<Rectangle> walls = new();


walls.Add(new Rectangle(300, 100, 60, 20));
walls.Add(new Rectangle(320, 0, 16, 20));
walls.Add(new Rectangle(150, 0, 32, 128));
walls.Add(new Rectangle(123, 0, 1800, 20));

Rectangle playerRect = new Rectangle(1, 50, 100, 100);
Rectangle enemyRect = new Rectangle(1000, 100, 100, 100);

string scene;

scene = "start";

while (!Raylib.WindowShouldClose())
{

  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.WHITE);

  Rectangle overlap = Raylib.GetCollisionRec(playerRect, enemyRect);

  Raylib.DrawRectangleRec(playerRect, Color.RED);
  Raylib.DrawRectangleRec(enemyRect, Color.BLUE);
  Raylib.DrawRectangleRec(overlap, Color.ORANGE);

  foreach (Rectangle wall in walls)
  {
    Raylib.DrawRectangleRec(wall, Color.DARKBLUE);
  }

  if (scene == "start")
  {

    Raylib.ClearBackground(Color.BLACK);
    Raylib.DrawRectangle(300, 300, 40, 40, Color.RED);
    Raylib.DrawText("lets go", 300, 300, 40, Color.YELLOW);
    


  }




  if (scene == "game")
  {

    enemyRect.Y += 1;

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
      playerRect.Y += 5;
    }

    if (playerRect.X < 0 || playerRect.X > 1699)
    {
      playerRect.X = -1;
    }

    if (playerRect.Y < 0 || playerRect.Y > 799)
    {
      playerRect.Y = -1;

    }



    bool isInAWall = false;

    for (int i = 0; i < walls.Count; i++)
    {
      if (i == 2) continue;
      if (Raylib.CheckCollisionRecs(playerRect, walls[i]))
      {
        isInAWall = true;
      }
    }

    if (isInAWall == true)
    {
      scene = "start";

    }

    /*foreach (Rectangle wall in walls)
      {
       if (Raylib.CheckCollisionRecs(playerRect, wall))
       {
     playerRect.X *= -1;
     playerRect.Y *= -1;

       }
     }*/


  }
  Raylib.EndDrawing();
}