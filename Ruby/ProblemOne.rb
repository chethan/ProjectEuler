#If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
# The sum of these multiples is 23.
## Find the sum of all the multiples of 3 or 5 below 1000.


class Problem_One
    TARGET=999

    def self.mine
        sum=0;
        (1 .. 999).each{|i|
            sum+=(i) if (i%3 ==0 || i%5==0)
        }
        p sum

    end

    def self.euler
        p sum_divisable_by(3)+sum_divisable_by(5)-sum_divisable_by(15)
    end


    def self.sum_divisable_by(n)
        p=(TARGET/n)
        n *p *(p+1) / 2
    end

end

Problem_One.mine
Problem_One.euler

