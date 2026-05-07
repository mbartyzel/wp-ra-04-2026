class Unit: 
    def __init__(self, name: str, symbol: str):
        self._name = name
        self._symbol = symbol

    @property
    def name(self) -> str: 
        return self._name

    @property
    def symbol(self) -> str: 
        return self._symbol

class Weight:
    def __init__(self, amout: dobule, metric: Unit)
        self._amount = amout
        self._metric = metric

    @property
    def amount(self) -> double: 
        return self._about

    @property
    def metric(self) -> Unit: 
        return self._metric

    def equals(self, weigt: Weight) -> bool:
        pass

    def add(self, weigt: Weight) -> Weight:


        return Weight(...);

    Weight(10, Unit("kilogram", "kg"))


