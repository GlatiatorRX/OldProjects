title = 'Test Script'
first_name = 'matt'
second_name = 'bolles'


def hello_world():
    # this is a comment
    print(title.title())
    print(first_name)
    print(second_name)


hello_world()

months = ['january', 'february', 'march', 'april', 'may', 'june',
          'july', 'august', 'september', 'october', 'november', 'december']

for month in months:
    print(month.title())

for value in range(1, 6):
    print(value)

# create range of numbers 1 to 101, but every loop in the range adds 2
numbers = list(range(1, 101, 2))
print(numbers)

squares = []
for value in range(1, 11):
    square = value ** 2
    squares.append(square)
print(squares)

print(months[2:4])
print(months[-3:])

months_copy = months[:]
print(months_copy)

username = input("What is your name?\n")
print("Hello " + username.title() + "!")
password = input("Please enter your password.\n")
if username.lower() == "matt" and password == "gay":
    print("Access granted!")
else:
    print("Incorrect. Please try again.")

birthday = input("What month is your birthday?\n")
if birthday.lower() in months:
    if birthday.lower() == "may":
        print("Happy Birthday!")
    else:
        print("No cake for you...")
elif birthday.lower() not in months:
    print("I said month dumbass")

# dictionaries
book_1 = {'author': "matt", 'price': 10}
print(book_1['author'])
print(book_1['price'])

for key, value in book_1.items():
    print("Key: " + key)
    print("Value: " + str(value))

print("=" * 30)
for key in book_1.keys():
    print(key)

for value in book_1.values():
    print(value)

if 'copyright' in book_1:
    print(book_1['copyright'])
else:
    print("Free game I guess")

del book_1['price']

print(book_1.get('price', "It's freeeeeee"))

prompt = "To end this program enter 'q' ~\n"
message = ""
while message.lower() != "q":
    message = input(prompt)
