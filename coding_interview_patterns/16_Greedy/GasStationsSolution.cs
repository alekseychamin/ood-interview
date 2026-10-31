// «Паттерны Coding Interview», глава 16: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.Greedy;

public static class GasStationsSolution {
    public static int GasStations(int[] gas, int[] cost) {
        // Если суммарное количество топлива меньше его суммарного
        // расхода, завершить круг невозможно.
        if (gas.Sum() < cost.Sum()) {
            return -1;
        }
        int start = 0, tank = 0;
        for (int i = 0; i < gas.Length; i++) {
            tank += gas[i] - cost[i];
            // Если значение tank отрицательное,
            // значит, мы не можем продолжать путь
            // ни с текущей стартовой точки, ни с любой предыдущей.
            if (tank < 0) {
                // Сбрасываем значение tank и пробуем начать со следующей
                // АЗС.
                start = i + 1;
                tank = 0;
            }
        }
        return start;
    }
}
