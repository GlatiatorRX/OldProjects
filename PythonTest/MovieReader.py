filename = "Movies.txt"
try:
    with open(filename) as file_object:
        # contents = file_object.read()
        # print(contents.strip())

        # for line in file_object:
        #    print(line.strip())

        lines = file_object.readlines()
except FileNotFoundError:
    # pass will allow silent failing
    pass
    # message = "Sorry, the file " + filename + " could not be found."
    # print(message)
else:
    for line in lines:
        print(line.strip())

    message = input("What is your favorite film? ")
    print(message.title())

    filename = 'MoviePrinter.txt'
    # with open(filename, 'w') as file_object:
    # file_object.write("Hello from movie reader\n")

    with open(filename, 'a') as file_object:
        file_object.write(message + "\n")
