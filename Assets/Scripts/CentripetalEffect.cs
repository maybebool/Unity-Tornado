public static class CentripetalEffect {
    
    // we need a positive return overall therefore the formula must be either
    // (+) + ((-) / (+)) * (-) || (+) + ((+) / (-)) * (-)
    
    /// <summary>
    /// Calculates the linear interpolation between two points based on a scalar value.
    /// </summary>
    /// <param name="scalarBetweenPoints">The scalar value between the two points.</param>
    /// <param name="firstPoint">The value of the first point.</param>
    /// <param name="secondPoint">The value of the second point.</param>
    /// <param name="firstInterpolationPoint">The interpolation value corresponding to the first point.</param>
    /// <param name="secondInterpolationPoint">The interpolation value corresponding to the second point.</param>
    /// <returns>
    /// The interpolated value based on the scalar value between the two points.
    /// </returns>
    public static float CalculateLinearInterpolation(this float scalarBetweenPoints, float firstPoint, float secondPoint, float firstInterpolationPoint, float secondInterpolationPoint) {
        return (scalarBetweenPoints - firstPoint) / (secondPoint - firstPoint) * (secondInterpolationPoint - firstInterpolationPoint) + firstInterpolationPoint;
    }
}
