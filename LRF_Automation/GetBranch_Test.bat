git for-each-ref --count=1 --sort=-committerdate --format=%(refname)  > branch2.txt
set /p Build2=<branch2.txt
echo $Build2