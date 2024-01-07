
using System.Diagnostics.Contracts;
using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);



List<Rectangle> walls = new();


walls.Add(new Rectangle(300, 100, 60, 20));
walls.Add(new Rectangle(320, 0, 16, 20));
walls.Add(new Rectangle(150, 0, 32, 128));
walls.Add(new Rectangle(123, 0, 1800, 20));


Rectangle rRect = new Rectangle(275, 260, 250, 100);
Rectangle playerRect = new Rectangle(1, 50, 100, 100);
Rectangle enemyRect = new Rectangle(1000, 100, 100, 100);

string scene;

scene = "start";

int liv = 1;

int score = 0;

/*--------------------------------------------------------------------------------------------------------------*/

while (!Raylib.WindowShouldClose())
{

if (scene == "start")
    {

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(rRect, Color.WHITE);
        Raylib.DrawText("Press space to start", 290, 300, 20, Color.RED);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            Raylib.ClearBackground(Color.BLACK);
            scene = "game";
        }
    }
  

  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.WHITE);

  

  Raylib.DrawRectangleRec(playerRect, Color.RED);
  Raylib.DrawRectangleRec(enemyRect, Color.BLUE);
  

  

  foreach (Rectangle wall in walls)
  {
    Raylib.DrawRectangleRec(wall, Color.DARKBLUE);
  }




  




  if (scene == "game")
  {

//render
        Raylib.DrawText($"points {score}", 50, 520, 40, Color.GRAY);
        Raylib.DrawText($"Health {liv}", 250, 520, 40, Color.GRAY);
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

    /*if (playerRect.X < 0 || playerRect.X > 1699)
    {
      playerRect.X -= 1;
    }

    if (playerRect.Y < 0 || playerRect.Y > 799)
    {
      playerRect.Y -= 1;

    }*/
    



    bool isInAWall = false;

     for (int i = 0; i < walls.Count; i++)
    {
     // if (i == 2) continue;
      if (Raylib.CheckCollisionRecs(playerRect, walls[i]))
      {
        isInAWall = true;
      }
    }

    if (isInAWall == true)
    {
     
     liv--;

    }

  if (liv < 0){
    scene = "start";
  }

    /*foreach (Rectangle wall in walls)
      {
       if (Raylib.CheckCollisionRecs(playerRect, wall))
       {
     playerRect.X -= playerRect.X;
     playerRect.Y -= playerRect.Y;

       }
     }*/
if(Raylib.CheckCollisionRecs(playerRect, enemyRect)){

score++;
enemyRect.Y= 0;
}

  }

  Raylib.EndDrawing();
}