namespace Network
{
    public class MatrixFactory
    {
        /// <summary>
        /// Creates the tube graph - (this would usually come from a data store)
        /// </summary>
        /// <returns></returns>
        public Station[,] CreateMatrix()
        {
            var matrix = new Station[14, 14];

            // embankment
            matrix[0,1] = new Station(new[]{RouteMedium.DistrictAndCircle });
            matrix[0,13] = new Station(new[]{RouteMedium.Northern,RouteMedium.Bakerloo,RouteMedium.Walking});

            // temple
            matrix[1,0] = new Station(new[] {RouteMedium.DistrictAndCircle});
            matrix[1,2] = new Station(new[] {RouteMedium.DistrictAndCircle});

            // blackfriars
            matrix[2,1] = new Station(new[] {RouteMedium.DistrictAndCircle});
            matrix[2,3] = new Station(new[] {RouteMedium.DistrictAndCircle});

            // mansion house
            matrix[3,2] = new Station(new[] {RouteMedium.DistrictAndCircle});
            matrix[3,4] = new Station(new[] {RouteMedium.DistrictAndCircle});

            // cannon street
            matrix[4,3] = new Station(new[] {RouteMedium.DistrictAndCircle});
            matrix[4,5] = new Station(new[] {RouteMedium.DistrictAndCircle});

            // monument
            matrix[5,4] = new Station(new[] {RouteMedium.DistrictAndCircle});
            matrix[5,6] = new Station(new[] {RouteMedium.Walking});

            // bank
            matrix[6,5] = new Station(new[] {RouteMedium.Walking});
            matrix[6,7] = new Station(new[] {RouteMedium.Central});

            // st pauls
            matrix[7,6] = new Station(new[] {RouteMedium.Central});
            matrix[7,8] = new Station(new[] {RouteMedium.Central});

            // chancery
            matrix[8,7] = new Station(new[] {RouteMedium.Central});
            matrix[8,9] = new Station(new[] {RouteMedium.Central});

            // holborn
            matrix[9,8] = new Station(new[] {RouteMedium.Central});
            matrix[9,10] = new Station(new[] {RouteMedium.Piccadilly});

            // covent garden
            matrix[10,9] = new Station(new[] {RouteMedium.Piccadilly});
            matrix[10,11] = new Station(new[] {RouteMedium.Piccadilly});

            // leicester square
            matrix[11,10] = new Station(new[] {RouteMedium.Piccadilly});
            matrix[11,12] = new Station(new[] {RouteMedium.Northern});

            // tottenham court road
            matrix[12,13] = new Station(new[] {RouteMedium.Northern});
            
            // charing cross
            matrix[13,0] = new Station(new[] {RouteMedium.Northern,RouteMedium.Bakerloo,RouteMedium.Walking});
            matrix[13,11] = new Station(new[] {RouteMedium.Northern});

            return matrix;
        }
    }
}
