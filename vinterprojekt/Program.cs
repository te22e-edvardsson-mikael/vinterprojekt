// See https://aka.ms/new-console-template for more information
using Raylib_cs;

Raylib.InitWindow(1800, 900, "vinterprojekt");
Raylib.SetTargetFPS(60);


while (!Raylib.WindowShouldClose())
{
  Raylib.BeginDrawing();
  
  Raylib.ClearBackground(Color.WHITE);
  
  Raylib.DrawRectangle(0,850,1800,50, Color.MAGENTA);
  
  Raylib.EndDrawing();
}