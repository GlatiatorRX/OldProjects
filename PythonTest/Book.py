# 1 / 16 / 2019
# Matt Bolles
# Create first class


class Book():
    """A class to create book."""

    def __init__(self, name, price, publisher):
        """Initialize the name, price, and publisher attributes"""

        self.name = name
        self.price = price
        self.publisher = publisher

    def hardback(self):
        print(self.name.title() + " is a hardback book")

    def softback(self):
        print(self.name.title() + " is a softback book")

    def ebook(self):
        print(self.name.title() + " is an ebook")

    def ebook_reader(self):
        print("Library: " + self.name.title() + ", $" +
              str(self.price) + ", " + self.publisher.title())


# Creating and instance of our book class
my_book = Book('elon musk', 14.99, 'virgin books')

# Accessing attributes
# print("I'm currently reading " + my_book.name.title() + ".")
# print("This book costs " + str(my_book.price) + ".")

my_book.ebook_reader()
