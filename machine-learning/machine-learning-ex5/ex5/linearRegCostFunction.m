function [J, grad] = linearRegCostFunction(X, y, theta, lambda)
%LINEARREGCOSTFUNCTION Compute cost and gradient for regularized linear 
%regression with multiple variables
%   [J, grad] = LINEARREGCOSTFUNCTION(X, y, theta, lambda) computes the 
%   cost of using theta as the parameter for linear regression to fit the 
%   data points in X and y. Returns the cost in J and the gradient in grad

% Initialize some useful values
m = length(y); % number of training examples

% You need to return the following variables correctly 
J = 0;
grad = zeros(size(theta));

% ====================== YOUR CODE HERE ======================
% Instructions: Compute the cost and gradient of regularized linear 
%               regression for a particular choice of theta.
%
%               You should set J to the cost and grad to the gradient.
%


h = X - theta';
error = h .- y;
reg = sum(theta .^ 2) * lambda/(2*m);
J = ((sum(error .^ 2)) * 1/(2*m)) + reg;

hh = theta(1) .+ (X * theta(2));

if(j == 0)
  grad = ((sum(hh - y)) * X) * 1/m;
else
  g1 = (sum(hh - y)) .* X;
  g2 = theta * (lambda/m);
  grad = (g1 * 1/m) + g2;
endif


% =========================================================================

grad = grad(:);

end
