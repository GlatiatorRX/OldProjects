import Ereader

my_new_ereader = Ereader.Ereader("Amazon Kindle", "Paperwhite",
                                 "Adjustable Backlight", "Several Months of Battery Life", "300dpi")
print(my_new_ereader.get_ereader_name())
my_new_ereader.update_library_count(48)
my_new_ereader.increment_library_count(3)
my_new_ereader.read_library_count()

my_kindle_fire = Ereader.KindleFire("Amazon", "Kindle Fire",
                                    "Backlight", "12 Hour Battery Life", "Color Screen")
print(my_kindle_fire.get_ereader_name())
my_kindle_fire.firescreen.describe_screen()

# Below is importing classes while above imports the entire python module

"""
from Ereader import Ereader, KindleFire

my_new_ereader = Ereader("Amazon Kindle", "Paperwhite",
                         "Adjustable Backlight", "Several Months of Battery Life", "300dpi")
print(my_new_ereader.get_ereader_name())
my_new_ereader.update_library_count(48)
my_new_ereader.increment_library_count(3)
my_new_ereader.read_library_count()

my_kindle_fire = KindleFire("Amazon", "Kindle Fire",
                            "Backlight", "12 Hour Battery Life", "Color Screen")
print(my_kindle_fire.get_ereader_name())
my_kindle_fire.firescreen.describe_screen()
"""
