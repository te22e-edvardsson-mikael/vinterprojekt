// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);



//List<Rectangle> = new List<Rectangle>();



while (!Raylib.WindowShouldClose())
{





  Raylib.BeginDrawing();


  
  Raylib.ClearBackground(Color.WHITE);

  
Rectangle playerRect = new Rectangle(50,50,100,100);
Rectangle enemyRect = new Rectangle(1000,100,100,100);
Rectangle overlap = Raylib.GetCollisionRec(playerRect, enemyRect);

Raylib.DrawRectangleRec(playerRect, Color.RED);
Raylib.DrawRectangleRec(enemyRect, Color.BLUE);
Raylib.DrawRectangleRec(overlap, Color.ORANGE);


string scene = "start";

if (scene == "start")
{
   if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
playerRect.X +=1;
}
   if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
playerRect.X -=1;
}

}

  
Raylib.EndDrawing();

}
