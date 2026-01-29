import random
import curses

# Opsæt skærm
screen = curses.initscr()
curses.curs_set(0)
height, width = screen.getmaxyx()
win = curses.newwin(height, width, 0, 0)
win.keypad(1)
win.timeout(100)

# Snake og mad initialisering
snake_x = width//4
snake_y = height//2
snake = [
    [snake_y, snake_x],
    [snake_y, snake_x-1],
    [snake_y, snake_x-2]
]
mad = [height//2, width//2]
win.addch(mad[0], mad[1], curses.ACS_PI)

key = curses.KEY_RIGHT
score = 0

while True:
    next_key = win.getch()
    key = key if next_key == -1 else next_key

    # Beregn ny position for snake's hoved
    y = snake[0][0]
    x = snake[0][1]
    if key == curses.KEY_DOWN:
        y += 1
    if key == curses.KEY_UP:
        y -= 1
    if key == curses.KEY_LEFT:
        x -= 1
    if key == curses.KEY_RIGHT:
        x += 1
    snake.insert(0, [y, x])

    # Tjek for collision med vægge eller sig selv
    if y in [0, height] or x in [0, width] or snake[0] in snake[1:]:
        curses.endwin()
        print(f"Game Over! Din score: {score}")
        break

    # Tjek om snake spiser mad
    if snake[0] == mad:
        score += 1
        mad = None
        while mad is None:
            ny_mad = [
                random.randint(1, height-2),
                random.randint(1, width-2)
            ]
            mad = ny_mad if ny_mad not in snake else None
        win.addch(mad[0], mad[1], curses.ACS_PI)
    else:
        tail = snake.pop()
        win.addch(tail[0], tail[1], ' ')

    win.addch(snake[0][0], snake[0][1], curses.ACS_CKBOARD)
