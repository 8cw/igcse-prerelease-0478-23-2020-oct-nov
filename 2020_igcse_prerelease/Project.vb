Module Project
    ''' <summary>
    ''' The number of fillings a user can choose for their baguette
    ''' </summary>
    Const NUM_FILLINGS = 1
    ''' <summary>
    ''' The amount of salad items a user can choose for their baguette
    ''' </summary>
    Const NUM_SALAD_ITEMS = 3

    ''' <summary>
    ''' The sizes of bread a user can choose for their baguette
    ''' </summary>
    Dim BAGUETTE_SIZES As Integer() = {30, 15}
    ''' <summary>
    ''' The available breads a user can choose for their baguette
    ''' </summary>
    Dim BAGUETTE_BREADS As String() = {"White", "Brown", "Seeded"}
    ''' <summary>
    ''' All the fillings the user is allowed to choose from
    ''' </summary>
    Dim FILLINGS_AVAILABLE As String() = {"Beef", "Chicken", "Cheese", "Egg", "Tuna", "Turkey"}
    ''' <summary>
    ''' All the salads the user is allowed to choose from
    ''' </summary>
    Dim SALADS_AVAILALE As String() = {"Lettuce", "Tomato", "Sweetcorn", "Cucumber", "Peppers"}

    ''' <summary>
    ''' Outputs the configuration of a baguette to the console.
    ''' </summary>
    ''' <param name="bread">The bread type of the baguette</param>
    ''' <param name="fillings">An array of strings that contains all the fillings in the baguette</param>
    ''' <param name="salads">An array of strings that contains all the salads in the baguette</param>
    Sub outputBaguette(bread As String, fillings As String(), salads As String())
        Console.WriteLine(String.Format("You have chosen {0} bread.", bread))

        For Each filling In fillings
            If filling <> "" Then
                Console.WriteLine(String.Format("- With filling {0}", filling))
            End If
        Next

        Console.WriteLine()

        For Each salad In salads
            If salad <> "" Then
                Console.WriteLine(String.Format("- With salad {0}", salad))
            End If
        Next
    End Sub

    ''' <summary>
    ''' Gets the user to create a baguette
    ''' </summary>
    ''' <returns>A tuple that contains the following:
    ''' - bread: The bread the user has chosen
    ''' - fillings: An array of fillings the user has chosen
    ''' - salads: An array of salads the user has chosen
    ''' </returns>
    Function createBaguette() As (bread As String, fillings As String(), salads As String())
        Dim baguetteBread As String = ""
        Dim baguetteFillings(NUM_FILLINGS - 1) As String
        Dim baguetteSalads(NUM_SALAD_ITEMS - 1) As String

        outputBaguette(baguetteBread, baguetteFillings, baguetteSalads)

        Return (baguetteBread, baguetteFillings, baguetteSalads)
    End Function

    Sub Main()
        createBaguette()

        Console.ReadLine()
    End Sub

End Module
