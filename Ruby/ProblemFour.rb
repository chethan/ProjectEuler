#A palindromic number reads the same both ways. The largest palindrome made
#from the product of two 2-digit numbers is 9009 = 91 × 99.
#Find the largest palindrome made from the product of two 3-digit numbers.


class Problem_Four

    def self.mine
       palindrome =1;
        999.downto(100){|i|
            i.downto(100){|j|
                product=i*j
                break unless product>palindrome
                palindrome = product if (product.to_s==product.to_s.reverse)
            }
        }
        p palindrome
    end

end

Problem_Four.mine

