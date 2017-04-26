Resources:

- Exercise tutorials
https://www.coursera.org/learn/machine-learning/discussions/all/threads/m0ZdvjSrEeWddiIAC9pDDA

Octave:
- Delete only first column: size(Theta1(:, 2:end))
- Delete only first row: size(Theta1(2:end, :))
- Delete the Columns 2 and 4 from matrix:  mymatrix(:,[2,4]) = []
- Delete the Rows 2 and 4 from matrix:  mymatrix([2,4],:) = []
- Add one row with ones to a matrix:
	b = [2 2 2; 3 3 3; 4 4 4]
	bb = [ones(3, 1) b]
	?bb =	1   2   2   2
		1   3   3   3
		1   4   4   4
	