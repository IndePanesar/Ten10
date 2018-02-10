﻿Feature: Ten10 List manipulation tests
Scenario Outline: I want to get the first longest ordered list from a list of random numbers
Given I have a list of unorderd integers '<unordered>'
When I process the list for the largest orderd list
Then I am given the first largest sublist and its size as '<sublist>' '<size>'
Examples: 
| unordered                          | sublist            | size |
| 1,2,3,4,5,6,4,3,5,7,84,100,100     | 1,2,3,4,5,6        | 6    |
| 1, 3, 5, 6, 3, 5, 6, 7, 8, 9, 0, 9 | 3,5,6,7,8,9        | 6    |
| 1, 2, 3, 4, 5, 6                   | 1,2,3,4,5,6        | 6    |
| 0, 0, 0, 0                         | 0                  | 1    |
| -1, -2, -3, -2, -1, 0, 1, 5,199    | -3,-2,-1,0,1,5,199 | 7    |
