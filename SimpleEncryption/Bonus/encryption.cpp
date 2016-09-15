#include <iostream>
#include <string.h>
 
using namespace std;
int keyCode = 18564;

void encrypt(char msg[],int key)
{
    int i;
    for(i=0;i<strlen(msg);++i)
    {
        msg[i] = msg[i] - key;
    }
}
 
void decrypt(char msg[],int key)
{
    int i;
    for(i=0;i<strlen(msg);++i)
    {
        msg[i] = msg[i] + key;
    }
}
int main()
{
    char messege[100] ;
    cout <<"Enter the Message: \n ";
    cin.getline(messege,100);
    cout <<"\nPassword = " << messege << endl;
    encrypt(messege,keyCode);
    cout <<"\nEncrypted value = " << messege << endl;
    decrypt(messege,keyCode);
    cout <<"\nDecrypted value = " << messege << endl << endl;

	system ("PAUSE");
}