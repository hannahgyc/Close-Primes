# Close-Primes
Game to find the closest stepped prime.

Design an encapsulated closePrime class. Each closePrime object encapsulates a 
‘hidden’ digit and, if active, returns the prime number that is ‘hidden’ steps 
away from a query. For example, an ‘active’ closePrime object encapsulating the 
digit ‘3’ would return 97 upon a ping passing in 75 (as the closest prime that 
is 3 primes away from 75: 79, 83, and 89 being the ‘3’ intermediary primes).
Every closePrime object is initially active but transitions to inactive if the
count of received values exceeds some multiple (other than 1) of its hidden digit.

The client programmer may query, reset, and/or revive a closePrime object in
addition to pinging values. An attempt to revive an active closePrime object 
causes that object to be permanently deactivated.
