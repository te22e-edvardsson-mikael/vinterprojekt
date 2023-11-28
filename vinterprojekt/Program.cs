// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);

Rectangle p = new Rectangle(50,50,50,50);
Rectangle e = new Rectangle(850,50,50,50);





while (!Raylib.WindowShouldClose())
{



  Raylib.BeginDrawing();


  
  Raylib.ClearBackground(Color.WHITE);

  //List<Rectangle> = new List<Rectangle>();


  
  Raylib.DrawRectangleRec(p, Color.SKYBLUE);
  Raylib.DrawRectangleRec(e, Color.RED);
  bool Overlapping = Raylib.CheckCollisionRecs(pRect, eRect);
  
  Raylib.EndDrawing();
}