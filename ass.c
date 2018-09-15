#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>
#include <cab202_graphics.h>
#include <cab202_sprites.h>
#include <cab202_timers.h>

// Game state.
bool game_over = false;    /* Set this to true when game is over */
bool update_screen = true; /* Set to false to prevent screen update. */
bool stop_treasure = false;

char *me_image =
    /**/ "ooOooo"
    /**/ "oooooo"
    /**/ "oooooo"
    /**/ "oooooo";

char *safe_platform_image =
    /**/ "=========="
    /**/ "==========";

char *unsafe_platform_image =
    /**/ "XXXXXXXXXX"
    /**/ "XXXXXXXXXX";

char *treasure_image =
    /**/ "I--I"
    /**/ "I__I";

char *treasure_image_two =
    /**/ "    "
    /**/ "I__I";

#define MAX_ITEM (1000)
#define MAX_BLOCK_WIDTH (10)
#define HORIZONTAL_SPACING (1)
#define INFO_HEIGHT (6)
#define ME_HEIGHT (4)

//Globals

int column_num;
int row_num;
int time_now;
int prior_blocks_y[MAX_ITEM];
sprite_id prior_blocks[MAX_ITEM];
sprite_id remaining_safe_platforms[MAX_ITEM];
sprite_id remaining_unsafe_platforms[MAX_ITEM];
sprite_id random_platforms[MAX_ITEM];
int ctr1 = 0;
int ctr2 = 0;
sprite_id me;
sprite_id treasure;
sprite_id start_platform;
int lives = 10;
int score = 0;
// int scores [999999];
time_t min = 0;
time_t sec = 0;
time_t count =0;
double me_fall_dy = 0.001;
double treasure_dx = 0.003;
double me_slide;
sprite_id global_collide;
sprite_id global_prior_collide;

//timer has issue
void mytime(){
    count++;
    if (count == screen_width() * 35){
        sec++;
        count = 0;
        if (sec == 60){
            min++;
            sec=0;
        }
    }
    
}

//a function to draw top info stuff
void draw_top_info()
{
    int first_info_width = screen_width()/2;
    draw_line(0, 0, screen_width() - 1, 0, '~');
    draw_string(0, 1, "Student number: n10176250");
    draw_string(0, 2, "Lives:");
    draw_int(6,2, lives);
    draw_string(first_info_width, 2, "Score:");
    draw_int(first_info_width+6 , 2, score);
    draw_string(0, 3, "Time:");
    draw_formatted(6,3,"%02d:%02d",min,sec);
    draw_line(0, 4, screen_width() - 1, 4, '~');
}

//function to set up must-be random safe platforms in each column
void set_up_prior_safe_blocks()
{
    column_num = screen_width() / (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING) - 1;
    //row num needs to minus top info height then divided by sprite height + 2 + block height
    row_num = (screen_height() - INFO_HEIGHT) / (ME_HEIGHT + 2 + 2) - 1;
    time_now = get_current_time();
    srand(time_now);
    for (int i = 0; i < column_num; i++)
    {
        //pick a random row in a column
        int random_rows = 1 + rand() % row_num;
        //pick a random block width
        int random_block_width = rand() % (10 - 5) + 5;
        //declare the must-be safe platforms
        double x = i * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING);
        double y = (random_rows) * (ME_HEIGHT + 2 + 2) + INFO_HEIGHT;
        random_platforms[i] = sprite_create(x, y, random_block_width, 2, safe_platform_image);
        prior_blocks[i] = random_platforms[i];
        //retrieve the y coord of the must-be pltforms for each column
        prior_blocks_y[i] = sprite_y(random_platforms[i]);
    }
}

// function that returns sprite id of a remaining platform
sprite_id rest_platform(int i, int n, char * image)
{
    double x = i * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING);
    double y = (n + 1) * (ME_HEIGHT + 2 + 2) + INFO_HEIGHT;

    int random_block_width = rand() % (10 - 5) + 5;
    sprite_id platform_set_up = sprite_create(x, y, random_block_width, 2, image);
    return platform_set_up;
}

// //function that set up the remaining platforms(ratio?)
void set_up_remaining_platforms()
{
    int safe_ctr = 0;
    int unsafe_ctr = 0;
    // srand(time_now);
    for (int i = 0; i < column_num; i++)
    {
        for (int n = 0; n < row_num; n++)
        {
            int random_platform = rand() % 6;
            if ((n + 1) * (ME_HEIGHT + 2 + 2) + INFO_HEIGHT != prior_blocks_y[i])
            {
                if (random_platform == 0 || random_platform == 1)
                {
                    safe_ctr++;
                    if (safe_ctr <= 160 - column_num)
                    {
                        random_platforms[column_num + ctr1 + ctr2] = rest_platform(i, n, safe_platform_image);
                        remaining_safe_platforms[ctr1] = random_platforms[column_num + ctr1 + ctr2];
                        ctr1++;
                    }
                }
                else if (random_platform == 2)
                {
                    unsafe_ctr++;
                    if (unsafe_ctr <= 40)
                    {
                        random_platforms[column_num + ctr1 + ctr2] = rest_platform(i, n, unsafe_platform_image);
                        remaining_unsafe_platforms[ctr2] = random_platforms[column_num + ctr1 + ctr2];
                        ctr2++;
                    }
                }
            }
        }
    }
}

//function to draw all the randomised platforms
void draw_random_platforms(sprite_id sid[])
{
    for (int i = 0; i < column_num + ctr1 + ctr2+1; i++)
    {
        sprite_draw(sid[i]);
    }
}

// function that sets up me and the treasure
void set_up_me()
{
    //create me & starting platform on the top right of the screen
    me = sprite_create((column_num) * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING),
                       (ME_HEIGHT + 2 + 2) + INFO_HEIGHT - 4, 6, 4, me_image);
    start_platform = sprite_create((column_num) * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING),
                                   (ME_HEIGHT + 2 + 2) + INFO_HEIGHT, 7, 2, safe_platform_image);
    random_platforms[column_num + ctr1 + ctr2] = start_platform;                        
    treasure = sprite_create(4, (row_num + 1) * (ME_HEIGHT + 2 + 2) + INFO_HEIGHT, 4, 2, treasure_image);
    //set speed according to the window
    me_fall_dy = screen_height() / 66000.0;
    treasure_dx = screen_width()/42000.0;
    //set me in gravity motion
    sprite_turn_to(me, 0.0, me_fall_dy);
    //set treasure in motion
    sprite_turn_to(treasure, treasure_dx, 0.0);
}
//function that returns the key pressed
int read_char()
{
    int keybutton = get_char();
    if (keybutton == 't')
    {
        stop_treasure = !stop_treasure;
    }
    return keybutton;
}

//function that moves character me
void move_me(sprite_id sid, int key, int window_width)
{

    int mx = sprite_x(sid);
    // int my = round(sprite_y(me));
    // me_slide = sprite_dx(sid);
    if (key == 'a' && mx > 0){
        // me_slide = -(screen_width()/ 66000.0);
        // me_fall_dy = 0;
        // sprite_step(sid);
        sprite_move(sid,-1,0);
    }
    if (key == 'd' && mx < window_width - sprite_width(sid)){
        // mdx = screen_width()/ 66000.0;
        sprite_move(sid, 1, 0);
    
}
}

//functiond to set teasure in auto movement
void moving_treasure(sprite_id sid)
{
    if (!stop_treasure)
    {
        sprite_step(sid);

        int tx = round(sprite_x(sid));
        // int ty = round( sprite_y( sid ) );
        double tdx = sprite_dx(sid);
        double tdy = sprite_dy(sid);
        if (tx % 2 == 0){
            sprite_set_image(treasure, treasure_image_two);
        }
        else{
            sprite_set_image(treasure, treasure_image);
        }

        if (tx == 0 || tx == screen_width() - sprite_width(sid))
        {
            tdx = -tdx;
        }
        if (tdx != sprite_dx(sid))
        {
            sprite_back(sid);
            sprite_turn_to(sid, tdx, tdy);
        }
    }
}
//function that checks whether two sprites collide, return boolean value
bool me_physics(sprite_id sid, sprite_id sid2)
{
    int top_me = sid->y;
    int btm_me = top_me + sid->height;
    int left_me = sid->x;
    int rght_me = left_me + sid->width - 1;
    // double mdx = sid -> dx;
    // double mdy = sid -> dy;

    int top_block = sid2->y;
    int btm_block = top_block + sprite_height(sid2) - 2;
    int left_block = sid2->x;
    int rght_block = left_block + sprite_width(sid2) - 1;

    if (btm_me < top_block)
        return false;
    if (btm_block < top_me)
        return false;
    if (left_me > rght_block)
        return false;
    if (left_block > rght_me)
        return false;

    else
        return true;
           
}
//check to see if the player is on the platform, returns the sprite id 
sprite_id on_platform(sprite_id sid, sprite_id sd[], int platform_num)
{
    sprite_id result = NULL;

    for (int i = 0; i < platform_num; i++)
    {
        if (me_physics(sid, sd[i]))
        {
            result = sd[i];
            break;
        }
    }
    return result;
}
//function to check if treasure collides with me
void t_collide(){
    if(me_physics(me, treasure)){
        lives += 2;
        sprite_destroy(me);
        sprite_destroy(treasure);
        me = sprite_create((column_num) * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING),
                       (ME_HEIGHT + 2 + 2) + INFO_HEIGHT - 4, 6, 4, me_image);
        treasure = sprite_create(4, (row_num + 1) * (ME_HEIGHT + 2 + 2) + INFO_HEIGHT, 4, 2, treasure_image);
        //set me in gravity motion
        sprite_turn_to(me, 0.0, me_fall_dy);
        //set treasure in motion
        sprite_turn_to(treasure, treasure_dx, 0.0);
        stop_treasure = false;
    }
}

//set_up local scope collision and compare with the global scope collision
void safe_local_collide(){
    sprite_id collided = on_platform(me, remaining_safe_platforms, ctr1-1);
    sprite_id prior_collided = on_platform(me, prior_blocks, column_num);
    if (collided != global_collide || prior_collided != global_prior_collide){
        score++;
    }
}
//set up global collision
void safe_global_collide(){
    global_collide = on_platform(me, remaining_safe_platforms, ctr1 -1);
    global_prior_collide = on_platform(me, prior_blocks, column_num);
}
//function to reset me when dead
void me_death(){
    for (int i = 0; i < ctr2; i++){
        if (me_physics(me, remaining_unsafe_platforms[i])){
            sprite_destroy(me);
            me = sprite_create((column_num) * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING),
                       (ME_HEIGHT + 2 + 2) + INFO_HEIGHT - 4, 6, 4, me_image);
            sprite_turn_to(me, 0.0, me_fall_dy);
            lives--;
        }
    }
    if (sprite_y(me) > screen_height()){
        sprite_destroy(me);
        me = sprite_create((column_num) * (MAX_BLOCK_WIDTH + HORIZONTAL_SPACING),
             (ME_HEIGHT + 2 + 2) + INFO_HEIGHT - 4, 6, 4, me_image);
        sprite_turn_to(me, 0.0, me_fall_dy);
        lives--;
    }
}

//functon to draw everything
void draw_all()
{
    draw_top_info();
    draw_random_platforms(random_platforms);
    sprite_draw(treasure);
    sprite_draw(me);
    // sprite_draw(start_platform);
}

//game over function
void game_end()
{
    //LAWRENCE END GAME CODE
    game_over = true;

    static char *msg_text = "GAME OVER, YOU SUCK! Press any key to exit.";
    int msg_width = strlen( msg_text ) / 2;
    int msg_height = 2;
    int msg_x = ( screen_width() - msg_width ) / 2;
    int msg_y = ( screen_height() - msg_height ) / 2;
    sprite_id msg = sprite_create( msg_x, msg_y, msg_width, msg_height, msg_text );
    clear_screen();
    sprite_draw( msg );
    draw_formatted(msg_x,msg_y+msg_height+1,"Score: %d", score);
    draw_formatted(msg_x, msg_y+msg_height+2, "Time played: %02d:%02d", min,sec);
    show_screen();

    // timer_pause( 1000 );
}

//Setup game
void setup(void)
{
    clear_screen();
    // srand(time_now);
    mytime();
    set_up_prior_safe_blocks();
    set_up_remaining_platforms();
    set_up_me();
    draw_all();
}

//play one turn of game
void process()
{
    clear_screen();
    mytime();
    int width = screen_width();
    // int height = screen_height();
    int key = read_char();
    t_collide();
    //scoreboard++ has issue
    safe_local_collide();
    safe_global_collide();
    moving_treasure(treasure);
    if (on_platform(me,random_platforms, column_num + ctr1 + ctr2 + 1)){
        // me_fall_dy = 0;
        move_me(me,key, width);
    }
    if (!on_platform(me, random_platforms, column_num + ctr1 + ctr2 + 1))
    {   
        me_fall_dy = screen_height() / 42000.0;
        sprite_step(me);
    }
    me_death();
    if (key == 'q'||lives == 0){
        game_over = true;        
    }
    //exit or restart game
    while (game_over == true){
        game_end();
        int key = get_char();
        if (key == 'q'){
            exit(0);
        }
        else if (key == 'r'){
            ctr1=0;
            ctr2=0;
            lives = 10;
            score = 0;
            min = 0;
            sec = 0;
            game_over = false;
            clear_screen();           
            setup();            
        }
    }
    draw_all();
}

//cleanup
void cleanup()
{
}

//program entry point
int main()
{
    setup_screen();
    setup();
    show_screen();
    while (!game_over)
    {
        process();

        if (update_screen)
        {
            show_screen();
        }

        // timer_pause( 10 );
    }
    cleanup();

    return 0;
}
