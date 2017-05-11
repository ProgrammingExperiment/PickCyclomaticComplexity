# Calculate [Cyclomatic complexity](https://en.wikipedia.org/wiki/Cyclomatic_complexity) in PICKBASIC Source Files #
We're going to calculate the number of conditional choices in logical flow in a PICKBASIC source file. 

We will count the numbre of IFs and CASE statements in the file. 

Here is an example taken from [PICK BASIC](http://jes.com/pb/pb_wp9.html)

```BASIC
PRINT "ENTER CHARACTER'S INITIAL" : INPUT INITIAL
IF INITIAL = "F" THEN NAME = "FRED FLINTSTONE" 
IF INITIAL = "W" THEN NAME = "WILMA FLINTSTONE" 
IF INITIAL = "P" THEN NAME = "PEBBLES FLINTSTONE" 
IF INITIAL = "D" THEN NAME = "DINO FLINTSTONE"
IF INITIAL # "F" AND INITIAL # "W" AND INITIAL # "P" AND INITIAL # "D" THEN NAME = "UNKNOWN"
PRINT NAME

PRINT "ENTER CHARACTER'S INITIAL" : 
INPUT INITIAL 
BEGIN CASE
  CASE INITIAL = "F"
    NAME = "FRED FLINTSTONE" 
  CASE INITIAL = "W"
    NAME = "WILMA FLINTSTONE" 
  CASE INITIAL = "P"
    NAME = "PEBBLES FLINTSTONE" 
  CASE INITIAL = "D"
    NAME = "DINO FLINTSTONE" 
  CASE 1
    NAME = "UNKNOWN"
END CASE
PRINT NAME

```

## Assignment 1: Count the “IF” statements in a text file.
 
### Input:
Directory containg text files
### Ouput: 
List of Filenames with the count of IF statements.



## Assignment 2: Count the “CASE” statements in a text file.
Reference: [PICK BASIC](http://jes.com/pb/pb_wp9.html)
### Input:
Directory containg text files
### Ouput: 
List of Filenames with the count of CASE statements.


## Assignment 3: Count the number of comments in a text file.
Reference: [PICK BASIC](http://jes.com/pb/pb_wp9.html)
In PICK, the '*' character start a comment in a line. 
As an example:
```
 * THIS IS A COMMENT
 IF INITIAL = "F" THEN NAME = "FRED FLINTSTONE"  * THIS IS ANOTHER COMMENT AFTER A LINE OF CODE 
```
### Input:
Directory containg text files
### Ouput: 
List of Filenames with the count of comments.

