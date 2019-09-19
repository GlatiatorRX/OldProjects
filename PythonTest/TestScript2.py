import json

phone_numbers = [123456789]
filename = "phone_number.json"
with open(filename, 'w') as file_object:
    json.dump(phone_numbers, file_object)

with open(filename) as file_object:
    phone_numbers = json.load(file_object)

print(phone_numbers)

#num = input("Pick a number. ")
num = 5
try:
    answer = 5/int(num)
except ZeroDivisionError:
    print("You cannot divide by zero.")
else:
    print(answer)

#from TestScript import hello_world
#print("Do this after TestScript import")
# hello_world()
#print("Do this last")
