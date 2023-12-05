% Top_AoC_D4.m 
%
% 12/4/2023
%

% required_numbers = [
%     41 48 83 86 17
%     13 32 20 16 61
%      1 21 53 59 44
%     41 92 73 84 69 
%     87 83 26 28 32
%     31 18 13 56 72
% ];
% 
% my_numbers = [
%     83 86  6 31 17  9 48 53
%     61 30 68 82 17 32 24 19
%     69 82 63 72 16 21 14  1
%     59 84 76 51 58  5 54 83
%     88 30 70 12 93 22 82 36
%     74 77 10 23 35 67 36 11
% ];
% 
% rawdata = readmatrix("example_input.txt");
% required_numbers = rawdata(:,3:7);
% my_numbers = rawdata(:,9:16);

rawdata = readmatrix("input.txt");
required_numbers = rawdata(:,3:12);  
my_numbers = rawdata(:,14:end);

winning_numbers_count = zeros(size(my_numbers,1),1);
instance_counts =        ones(size(my_numbers,1),1);
point_values =          zeros(size(my_numbers,1),1);

for i=1:size(my_numbers,1)
    count = length(intersect(required_numbers(i,:),my_numbers(i,:)));
    if(count > 0)
        winning_numbers_count(i) = count;
        point_values(i) = 2^(count-1);
        instance_counts(i+(1:count)) = instance_counts(i+(1:count)) + instance_counts(i);
    end
end

fprintf("Sum of point values: %d\n",sum(point_values));
fprintf("Total number of cards: %d\n",sum(instance_counts));

AoC_D4_Visualization;

