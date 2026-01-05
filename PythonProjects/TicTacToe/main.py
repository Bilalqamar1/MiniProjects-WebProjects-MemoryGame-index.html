# Tic Tac Toe - lavet af Bilal
# Simpelt Python-projekt for at lære programmering og logik

board = [" " for _ in range(9)]

def print_board():
    print()
    print(board[0], "|", board[1], "|", board[2])
    print("--+---+--")
    print(board[3], "|", board[4], "|", board[5])
    print("--+---+--")
    print(board[6], "|", board[7], "|", board[8])
    print()

def check_winner(player):
    wins = [
        [0,1,2],[3,4,5],[6,7,8],
        [0,3,6],[1,4,7],[2,5,8],
        [0,4,8],[2,4,6]
    ]
    return any(all(board[i] == player for i in combo) for combo in wins)

current_player = "X"

while True:
    print_board()
    move = int(input(f"Spiller {current_player}, vælg felt (1-9): ")) - 1

    if board[move] != " ":
        print("Felt optaget!")
        continue

    board[move] = current_player

    if check_winner(current_player):
        print_board()
        print(f"Spiller {current_player} vandt!")
        break

    if " " not in board:
        print("Uafgjort!")
        break

    current_player = "O" if current_player == "X" else "X"
Add Tic Tac Toe game in Python
