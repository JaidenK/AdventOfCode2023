index = (1:length(point_values))';
req_index = repmat(index,1,size(required_numbers,2));
my_index = repmat(index,1,size(my_numbers,2));

%% Scatter plot of numbers
figure();
grid on
grid minor
hold on
for i = 1:length(winning_numbers)
    s0 = scatter(winning_numbers{i},i*ones(length(winning_numbers{i})),25,[1 0 0]);
end
s1 = scatter(required_numbers',req_index',15,[0 0.8 0],'filled','o');
s2 = scatter(my_numbers',my_index',25,[0 0.5 0],'x');

ylim([0 length(point_values)]);
xlim([0 100]);
xlabel("Number");
ylabel("Card ID");
legend([s0 s1(1) s2(1)],"Winning Number", "Required Numbers","My Numbers");
title("Advent of Code - Day 4 - Scratchcards");

%% Plotting points
% figure();
% grid on
% grid minor
% hold on
% plot(winning_numbers_count);
% plot(point_values);
% xlabel("Card ID");
% ylabel("Value");
% xlim([0 length(point_values)]);