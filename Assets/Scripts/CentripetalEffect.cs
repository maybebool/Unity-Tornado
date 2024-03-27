public static class CentripetalEffect {
    // scalarBetweenAB = scalarAB = (fluid value based on scalar)
    // posPointA = a   posPointB = b   ToA = c  ToB = d
    // to inverse the linear interpolation we need negative values for (d - c)
    // possible is also a positive value for (b - a) if a is higher then max Scalar value of AB
        
    // we need a positive return overall therefore the formula must be either
    // (+) + ((-) / (+)) * (-) || (+) + ((+) / (-)) * (-)
    public static float CalculateLinearInterpolation(this float scalarBetweenPoints, float firstPoint, float secondPoint, float firstInterpolationPoint, float secondInterpolationPoint) {
        return (scalarBetweenPoints - firstPoint) / (secondPoint - firstPoint) * (secondInterpolationPoint - firstInterpolationPoint) + firstInterpolationPoint;
    }
}
