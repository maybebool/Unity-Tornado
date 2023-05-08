
public static class CentripetalEffect {
    // scalarBetweenAB = scalarAB = (fluid value based on scalar)
    // posPointA = a   posPointB = b   ToA = c  ToB = d
    // to inverse the linear interpolation we need negative values for (d - c)
    // possible is also a positive value for (b - a) if a is higher then max Scalar value of AB
        
    // we need a positive return overall therefore the formula must be either
    // (+) + ((-) / (+)) * (-) || (+) + ((+) / (-)) * (-)
        
    // Bezier Curve explaining of a + (b - a) * t
    public static float TornadoRotation(this float scalarAb, float a, float b, float c, float d) {
        return (scalarAb - a) / (b - a) * (d - c) + c;
    }
}
