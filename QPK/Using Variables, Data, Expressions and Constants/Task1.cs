//ORIGINAL:
public class Size
{
  public double wIdTh, Viso4ina;
  public Size(double w, double h)
  {
    this.wIdTh = w;
    this.Viso4ina = h;
  }
}

public static Size GetRotatedSize(
  Size s, double angleOfTheFigureThatWillBeRotaed)
{
  return new Size(
    Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
      Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina,
    Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh + 
      Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);

//REFACTORED:
public class Rectangle
{
  public double width, height;
  public Rectangle(double width, double height)
  {
    this.width = width;
    this.height = height;
  }
}

private double CalculateDistance(double angle, double deltaX, double deltaY)
{
	double distanceX = Math.Abs(Math.Cos(angle)) * deltaX;
	double distanceY = Math.Abs(Math.Sin(angle)) * deltaY;
	return distanceX + distanceY;
}

public static Rectangle GetRotatedRectangle(Rectangle rectangle, double angle)
{
	private double outputSizeX =  CalculateDistance(angle, rectangle.width, rectangle.height);
	private double outputSizeY =  CalculateDistance(angle, rectangle.height, rectangle.width);
    return new Rectangle(outputSizeX, outputSizeY);
}