int valX = 0;
int valY = 0;
int initializeX;
int initializeY;
const int joyPinX = A0;
const int joyPinY = A1;

void setup() {
  pinMode(joyPinX, INPUT);              
  pinMode(joyPinY, INPUT); 
  Serial.begin(9600);
  initializeX = map(analogRead(joyPinX),0,1023,-100,100)*-1;
  initializeY = map(analogRead(joyPinY),0,1023,-100,100)*-1;

}

void loop() {
  valX = map(analogRead(joyPinX),0,1023,-100,100)+initializeX;
  valY = map(analogRead(joyPinY),0,1023,-100,100)+initializeY;
  if(valX>=2 ){
    valX=1;
  }
  else if(valX<=-2){
    valX=-1;
  }
  else{
    valX=0;
  }
  if(valY>=2){
    valY=1;
  }
  else if(valY<=-2){
    valY=-1;
  }
  else{
    valY=0;
  }
  Serial.print(valX);
  Serial.print(",");
  Serial.println(valY);
  delay(20);
}
