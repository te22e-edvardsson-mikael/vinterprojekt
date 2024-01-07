
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



Color[] enemyColors = new Color[] { Color.BLUE, Color.PURPLE, Color.RED, Color.ORANGE };

int enemyColorss = 0;

string scene;

scene = "start";

int liv = 1;

int score = 0;

float enemyVelocityY = 1f;

bool spaceKeyReleased = true;

/*--------------------------------------------------------------------------------------------------------------*/

while (!Raylib.WindowShouldClose())
{

if (scene == "start")
    {

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(rRect, Color.BLACK);
        Raylib.DrawText("Press space to start", 290, 300, 20, Color.RED);

      if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && spaceKeyReleased)
        {
            Raylib.ClearBackground(Color.BLACK);

            scene = "game";

            playerRect.X = 1;
            playerRect.Y = 50;
            
            spaceKeyReleased = false; 
        }

      if (Raylib.IsKeyReleased(KeyboardKey.KEY_SPACE))
        {
            spaceKeyReleased = true;
        }
    }

  else if (scene == "game")
  {
    Raylib.ClearBackground(Color.WHITE);
    Raylib.BeginDrawing();

//render
Raylib.DrawText($"points {score}", 50, 520, 40, Color.GRAY);
Raylib.DrawText($"Health {liv}", 250, 520, 40, Color.GRAY);
  


  

  Raylib.DrawRectangleRec(playerRect, Color.RED);
  Raylib.DrawRectangleRec(enemyRect, enemyColors[enemyColorss]);


enemyRect.Y +=enemyVelocityY;

if (enemyRect.Y <= 0 || enemyRect.Y + 100 >= 900){
  enemyVelocityY = -enemyVelocityY;
}

foreach (Rectangle wall in walls)
  {
    Raylib.DrawRectangleRec(wall, Color.DARKBLUE);
  }

  
    

   

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

    spaceKeyReleased = true;
  }


  
if(Raylib.CheckCollisionRecs(playerRect, enemyRect)){

enemyColorss = (enemyColorss + 1) % enemyColors.Length;

score++;

Random random = new Random();
enemyRect.X = random.Next(1, 1901);
enemyRect.Y= random.Next(1, 801);
}

  }

  Raylib.EndDrawing();
}

  /*foreach (Rectangle wall in walls)
      {
       if (Raylib.CheckCollisionRecs(playerRect, wall))
       {
     playerRect.X -= playerRect.X;
     playerRect.Y -= playerRect.Y;

       }
     }*/

         /*if (playerRect.X < 0 || playerRect.X > 1699)
    {
      playerRect.X -= 1;
    }

    if (playerRect.Y < 0 || playerRect.Y > 799)
    {
      playerRect.Y -= 1;

    }*/
    