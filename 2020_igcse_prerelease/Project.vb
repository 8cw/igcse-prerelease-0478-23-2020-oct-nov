Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime

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
    Dim BAGUETTE_SIZES As Integer() = {15, 30}
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
    ''' A unique integer that gets incremented everytime we make an order
    ''' </summary>
    Dim LAST_ORDER_ID As Integer = 0

    ''' <summary>
    ''' The amount ordered for each baguette size
    ''' </summary>
    Dim BAGUETTE_SIZES_ORDERED As Integer() = {0, 0}
    ''' <summary>
    ''' The amount ordered for each baguette bread
    ''' </summary>
    Dim BAGUETTE_BREADS_ORDERED As Integer() = {0, 0, 0}
    ''' <summary>
    ''' The amount ordered for each baguette filling
    ''' </summary>
    Dim BAGUETTE_FILLINGS_ORDERED As Integer() = {0, 0, 0, 0, 0, 0}
    ''' <summary>
    ''' The amount ordered for each baguette salads
    ''' </summary>
    Dim BAGUETTE_SALADS_ORDERED As Integer() = {0, 0, 0, 0, 0}

    ''' <summary>
    ''' Outputs the configuration of a baguette to the console.
    ''' </summary>
    ''' <param name="bread">The bread type of the baguette</param>
    ''' <param name="fillings">An array of strings that contains all the fillings in the baguette</param>
    ''' <param name="salads">An array of strings that contains all the salads in the baguette</param>
    Sub outputBaguette(bread As String, fillings As String(), salads As String())
        Console.WriteLine("Your order is the following:")
        Console.WriteLine(String.Format("- {0} bread.", bread))

        Console.WriteLine()

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
    ''' VB.Net pre-allocates the memory of arrays with the default value of the type of array (e.g. making an string(2) will fill the 3 spaces with an empty string).
    ''' 
    ''' To properly count the amount of elements in an array, we can use this function.
    ''' </summary>
    ''' <param name="arr">The array to count the amount of elements in it</param>
    ''' <returns>The amount of elements inside the array</returns>
    Function getElementsInArray(arr As String()) As Integer
        Dim size As Integer = 0

        For Each i In arr
            If i <> "" Then
                size += 1
            End If
        Next

        Return size
    End Function

    ''' <summary>
    ''' Asks the user what bread size they would like to order
    ''' </summary>
    ''' <param name="currentSize">An optional parameter describing the currently selected bread size if they have one. If this exists, the program will ask if they wish to modify their bread size choice.</param>
    ''' <returns>The bread the user wants</returns>
    Function getBaguetteSize(Optional currentSize As Integer = 0) As Integer
        If currentSize <> 0 Then
            ' Display current baguette size if they have baguette size, and ask if they want to alter it
            Console.WriteLine(String.Format("You have chosen {0} bread size currently", currentSize))

            Dim shouldAlterBreadSize = ""
            While shouldAlterBreadSize <> "yes" And shouldAlterBreadSize <> "no"
                Console.Write("Do you want to alter your bread (yes/no)? ")
                Console.ReadLine().ToLower()
            End While

            If shouldAlterBreadSize <> "yes" Then
                Return currentSize
            End If
        End If

        Dim newBreadSize As Integer = 0
        While BAGUETTE_SIZES.Contains(newBreadSize) = False
            ' Ask for bread
            Console.WriteLine(String.Format("What bread size would you like? Enter the size in cm.{0}You can choose:{0}- 15cm{0}- 30cm", Environment.NewLine))

            Try
                newBreadSize = CInt(Console.ReadLine())
            Catch ex As Exception
                Console.WriteLine("Please only choose either 15cm or 30cm bread")
            End Try
        End While

        Return newBreadSize
    End Function

    ''' <summary>
    ''' Asks the user what bread they would like to order
    ''' </summary>
    ''' <param name="currentBread">An optional parameter describing the currently selected bread if they have one. If this exists, the program will ask if they wish to modify their bread choice.</param>
    ''' <returns>The bread the user wants</returns>
    Function getBread(Optional currentBread As String = "") As String
        ' Display current bread if they have bread, and ask if they want to alter it
        If currentBread <> "" Then
            Console.WriteLine(String.Format("You have chosen {0} bread currently", currentBread))

            Dim shouldAlterBread = ""
            While shouldAlterBread <> "yes" And shouldAlterBread <> "no"
                Console.Write("Do you want to alter your bread (yes/no)? ")
                Console.ReadLine().ToLower()
            End While

            If shouldAlterBread <> "yes" Then
                Return currentBread
            End If
        End If

        Dim newBread As String = ""
        While BAGUETTE_BREADS.Contains(newBread) = False
            ' Ask for bread
            Console.WriteLine(String.Format("What bread would you like? You can choose:{0}- White{0}- Brown{0}- Seeded", Environment.NewLine))

            newBread = Console.ReadLine()
        End While

        Return newBread
    End Function

    ''' <summary>
    ''' Gets the fillings for a baguette
    ''' </summary>
    ''' <param name="currentFillings">The current fillings the user has</param>
    ''' <returns>The fillings the user wants</returns>
    Function getFillings(Optional currentFillings As String() = Nothing) As String()
        If currentFillings Is Nothing Then
            currentFillings = {}
        End If

        If getElementsInArray(currentFillings) <> 0 Then
            ' There is currently fillings, display them
            Console.WriteLine("Your current fillings are:")
            For Each filling In currentFillings
                Console.WriteLine(String.Format("- {0}", filling))
            Next

            ' Ask if they wish to modify
            Dim shouldAlterFillings = ""
            While shouldAlterFillings <> "yes" And shouldAlterFillings <> "no"
                Console.Write("Do you want to change your fillings (yes/no)? ")
                shouldAlterFillings = Console.ReadLine().ToLower()
            End While

            If shouldAlterFillings <> "yes" Then
                Return currentFillings
            End If
        End If

        ' Declare size of array
        ReDim currentFillings(NUM_FILLINGS - 1)

        Console.WriteLine(String.Format("The filling options available are:{0}-Beef{0}-Chicken{0}-Cheese{0}-Egg{0}-Tuna{0}-Turkey", Environment.NewLine))
        For i = 0 To NUM_FILLINGS - 1
            Dim requestedFilling = ""
            While FILLINGS_AVAILABLE.Contains(requestedFilling) = False
                Console.Write("Please select a filling: ")
                requestedFilling = Console.ReadLine()
            End While

            currentFillings(i) = requestedFilling
        Next

        Return currentFillings
    End Function

    ''' <summary>
    ''' Gets the salads for a baguette
    ''' </summary>
    ''' <param name="currentSalads">The current salad the user has</param>
    ''' <returns>The salads the user wants</returns>
    Function getSalads(Optional currentSalads As String() = Nothing) As String()
        If currentSalads Is Nothing Then
            currentSalads = {}
        End If

        If getElementsInArray(currentSalads) <> 0 Then
            ' There is currently salads, display them
            Console.WriteLine("Your current salads are:")
            For Each salad In currentSalads
                Console.WriteLine(String.Format("- {0}", salad))
            Next

            ' Ask if they wish to modify their salad choice
            Dim shouldAlterSalads = ""
            While shouldAlterSalads <> "yes" And shouldAlterSalads <> "no"
                Console.ReadLine().ToLower()
                Console.Write("Do you want to change your salads (yes/no)? ")
            End While

            If shouldAlterSalads <> "yes" Then
                Return currentSalads
            End If
        End If

        ' Declare size of array
        ReDim currentSalads(NUM_SALAD_ITEMS - 1)

        Console.WriteLine(String.Format("The salad options available are:{0}-Lettuce{0}-Tomato{0}-Sweetcorn{0}-Cucumber{0}-Peppers", Environment.NewLine))
        For i = 0 To NUM_SALAD_ITEMS - 1
            Dim requestedSalad = "DEFAULT"
            While SALADS_AVAILALE.Contains(requestedSalad) = False And requestedSalad <> ""
                If requestedSalad <> "DEFAULT" Then
                    Console.WriteLine(String.Format("Current salad is '{0}'", requestedSalad))
                End If
                Console.Write("Please select a salad: ")
                requestedSalad = Console.ReadLine()
            End While

            ' If the user didn't want salad, don't give :)
            If requestedSalad = "" Then
                Exit For
            End If

            currentSalads(i) = requestedSalad
        Next

        Return currentSalads
    End Function

    Function modifyBaguette(breadSize As Integer, bread As String, fillings As String(), salads As String()) As (bread As String, fillings As String(), salads As String())
        ' Modify bread size
        Console.WriteLine("Do you wish to change your bread size (yes/no)?: ")
        Dim shouldChangeBreadSize = Console.ReadLine().ToLower()
        If shouldChangeBreadSize = "yes" Then
            breadSize = getBaguetteSize(breadSize)
        End If

        ' Modify bread
        Console.Write("Do you wish to change your bread (yes/no)?: ")
        Dim shouldChangeBread = Console.ReadLine().ToLower()
        If shouldChangeBread = "yes" Then
            bread = getBread(bread)
        End If

        ' Modify fillings
        Console.Write("Do you wish to change your fillings (yes/no)?: ")
        Dim shouldChangeFillings = Console.ReadLine().ToLower()
        If shouldChangeFillings = "yes" Then
            fillings = getFillings(fillings)
        End If

        ' Modify salads
        Console.Write("Do you wish to change your salads (yes/no)?: ")
        Dim shouldChangeSalads = Console.ReadLine().ToLower()
        If shouldChangeSalads = "yes" Then
            salads = getSalads(salads)
        End If

        Return (bread, fillings, salads)
    End Function


    ''' <summary>
    ''' Gets the user to create a baguette
    ''' </summary>
    ''' <returns>A tuple that contains the following:
    ''' - breadSize: The bread size the user has chosen
    ''' - bread: The bread the user has chosen
    ''' - fillings: An array of fillings the user has chosen
    ''' - salads: An array of salads the user has chosen
    ''' </returns>
    Function createBaguette() As (breadSize As Integer, bread As String, fillings As String(), salads As String())
        ' Ask the user for the options
        Dim baguetteSize = getBaguetteSize()
        Dim baguetteBread = getBread()
        Dim baguetteFillings = getFillings()
        Dim baguetteSalads = getSalads()

        Dim shouldModify = ""
        While shouldModify <> "no"
            Console.Clear()
            outputBaguette(baguetteBread, baguetteFillings, baguetteSalads)
            Console.Write("Do you wish to modify your order (yes/no)?: ")
            shouldModify = Console.ReadLine().ToLower()
            If shouldModify = "yes" Then
                Dim newBaguette = modifyBaguette(baguetteSize, baguetteBread, baguetteFillings, baguetteSalads)
                baguetteBread = newBaguette.bread
                baguetteFillings = newBaguette.fillings
                baguetteSalads = newBaguette.salads
            End If
        End While

        Dim shouldContinue = ""
        While shouldContinue <> "yes" And shouldContinue <> "yes"
            Console.Clear()
            outputBaguette(baguetteBread, baguetteFillings, baguetteSalads)
            Console.Write("Do you wish to continue (yes/no)?: ")
            shouldContinue = Console.ReadLine().ToLower()

            If shouldContinue = "no" Then
                Return (0, "", {""}, {""})
            End If
        End While

        ' Add to incrementors
        ' Increment bread size
        For i = 0 To BAGUETTE_SIZES.Length - 1
            Dim baguettePossibleSize = BAGUETTE_SIZES(i)
            If baguettePossibleSize = baguetteSize Then
                BAGUETTE_SIZES_ORDERED(i) += 1
            End If
        Next
        ' Increment bread type
        For i = 0 To BAGUETTE_BREADS.Length - 1
            Dim baguettePossibleType = BAGUETTE_BREADS(i)
            If baguettePossibleType = baguetteBread Then
                BAGUETTE_BREADS_ORDERED(i) += 1
            End If
        Next
        ' Increment bread fillings
        For i = 0 To FILLINGS_AVAILABLE.Length - 1
            Dim baguettePossibleFilling = FILLINGS_AVAILABLE(i)
            For j = 0 To baguetteFillings.Length - 1
                Dim baguetteFillingUsed = baguetteFillings(j)
                If baguetteFillingUsed = baguettePossibleFilling Then
                    BAGUETTE_FILLINGS_ORDERED(i) += 1
                End If
            Next
        Next
        ' Increment bread salads
        For i = 0 To SALADS_AVAILALE.Length - 1
            Dim baguettePossibleSalads = SALADS_AVAILALE(i)
            For j = 0 To baguetteSalads.Length - 1
                Dim baguetteSaladsUsed = baguetteSalads(j)
                If baguetteSaladsUsed = baguettePossibleSalads Then
                    BAGUETTE_SALADS_ORDERED(i) += 1
                End If
            Next
        Next

        LAST_ORDER_ID += 1
        Return (baguetteSize, baguetteBread, baguetteFillings, baguetteSalads)
    End Function

    Sub generateDayReport()
        Console.Clear()
        ' Output total report, and baguettes total ordered
        Console.WriteLine(String.Format("Today's report for baguettes:{0}- Total baguettes ordered: {1}{0}Bread sizes ordered:", Environment.NewLine, LAST_ORDER_ID))
        ' Output bread sizes
        For i = 0 To BAGUETTE_SIZES.Length - 1
            Dim breadSize = BAGUETTE_SIZES(i)
            Dim breadOrderAmount = BAGUETTE_SIZES_ORDERED(i)
            Console.WriteLine(String.Format("- Bread size {0}cm was ordered {1} times", breadSize, breadOrderAmount))
        Next
        ' Output bread types
        Console.WriteLine("Baguette breads ordered:")
        For i = 0 To BAGUETTE_BREADS.Length - 1
            Dim breadType = BAGUETTE_BREADS(i)
            Dim breadOrderAmount = BAGUETTE_BREADS_ORDERED(i)
            Console.WriteLine(String.Format("- Bread type {0} was ordered {1} times", breadType, breadOrderAmount))
        Next
        ' Output bread fillings
        Console.WriteLine("Baguette fillings ordered:")
        For i = 0 To FILLINGS_AVAILABLE.Length - 1
            Dim fillingType = FILLINGS_AVAILABLE(i)
            Dim fillingOrderAmount = BAGUETTE_FILLINGS_ORDERED(i)
            Console.WriteLine(String.Format("- Filling {0} was ordered {1} times", fillingType, fillingOrderAmount))
        Next
        ' Output bread salads
        Console.WriteLine("Baguette salads ordered:")
        For i = 0 To SALADS_AVAILALE.Length - 1
            Dim saladType = SALADS_AVAILALE(i)
            Dim saladOrderAmount = BAGUETTE_SALADS_ORDERED(i)
            Console.WriteLine(String.Format("- Salad {0} was ordered {1} times", saladType, saladOrderAmount))
        Next

        ' Get least and most popular baguette fillings
        Dim leastPopularFilling As Integer() = {0, 1000000}
        Dim mostPopularFilling As Integer() = {0, 0}

        For i = 0 To BAGUETTE_FILLINGS_ORDERED.Length - 1
            Dim filling = BAGUETTE_FILLINGS_ORDERED(i)

            If filling < leastPopularFilling(1) Then
                leastPopularFilling = {i, filling}
            End If
            If filling > mostPopularFilling(1) Then
                mostPopularFilling = {i, filling}
            End If
        Next

        Console.WriteLine(String.Format("Least popular filling - {1}{0}Most popular filling - {2}", Environment.NewLine, FILLINGS_AVAILABLE(leastPopularFilling(0)), FILLINGS_AVAILABLE(mostPopularFilling(0))))
    End Sub

    Sub Main()
        While True
            Console.Write("Would you like to make a baguette? ")
            Dim shouldCreateBaguette = Console.ReadLine().ToLower()

            If shouldCreateBaguette = "yes" Then
                Dim baguette = createBaguette()
                If baguette.bread <> "" Then
                    outputBaguette(baguette.bread, baguette.fillings, baguette.salads)
                    Console.WriteLine(String.Format("Your order id is {0}", LAST_ORDER_ID))
                Else
                    ' User didn't want to continue with order
                End If
            End If

            Console.Write("Would you like the daily report? ")
            Dim shouldOutputDailyReport = Console.ReadLine().ToLower()

            If shouldOutputDailyReport = "yes" Then
                generateDayReport()
            End If
        End While

    End Sub

End Module
