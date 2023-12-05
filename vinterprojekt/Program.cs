// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);



//List<Rectangle> = new List<Rectangle>();

Rectangle playerRect = new Rectangle(50, 50, 100, 100);
Rectangle enemyRect = new Rectangle(1000, 100, 100, 100);
playerRect.X = 0;
playerRect.Y = 0;
string scene = "start";

while (!Raylib.WindowShouldClose())
{




  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.WHITE);

  Rectangle overlap = Raylib.GetCollisionRec(playerRect, enemyRect);

  Raylib.DrawRectangleRec(playerRect, Color.RED);
  Raylib.DrawRectangleRec(enemyRect, Color.BLUE);
  Raylib.DrawRectangleRec(overlap, Color.ORANGE);


  if (scene == "start")
  {
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
    playerRect.X *= -1;
  }

  if (playerRect.Y < 0  || playerRect.Y > 799) {
    playerRect.Y *= -1;
  }

  }


  Raylib.EndDrawing();

}
