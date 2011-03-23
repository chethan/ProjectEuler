#The sum of the squares of the first ten natural numbers is,
#1^(2) + 2^(2) + ... + 10^(2) = 385
#The square of the sum of the first ten natural numbers is,
#(1 + 2 + ... + 10)^(2) = 55^(2) = 3025
#Hence the difference between the sum of the squares of the first ten natural numbers
#and the square of the sum is 3025 ? 385 = 2640.
#Find the difference between the sum of the squares of the first one hundred natural numbers
#and the square of the sum.


class Problem_Six
    TARGET=100

    def self.mine
        return (square_of_sum_untill(TARGET)-sum_of_squares_untill(TARGET))
    end

    def self.euler
        return ((TARGET * (TARGET+1) /2)**2) - (TARGET * (TARGET+1) * (TARGET*2+1) / 6)
    end


    def self.sum_of_squares_untill(n)
        sum=0;
        1.upto(n){|i|
            sum+=(i**2)
        }
        return sum;
    end

    def self.square_of_sum_untill(n)
        sum=(n*(n+1)/2)
        sum*sum
    end

end

p Problem_Six.mine
p Problem_Six.euler

