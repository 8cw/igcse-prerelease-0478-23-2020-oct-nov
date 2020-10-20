Module Project
    ''' <summary>
    ''' Either 15 or 30 for cm
    ''' </summary>
    Dim baguetteSize As Integer
    ''' <summary>
    ''' Either White, Brown or Seeded
    ''' </summary>
    Dim breadType As String

    ''' <summary>
    ''' "Beef", "Chicken", "Cheese", "Egg", "Tuna", "Turkey"
    ''' </summary>
    Dim breadFilling As String

    ''' <summary>
    ''' "Lettuce", "Tomato", "Sweetcorn", "Cucumber", "Peppers"
    ''' </summary>
    Dim breadSalad1 As String
    Dim breadSalad2 As String
    Dim breadSalad3 As String

    Dim currentOrderId As Integer = 0

    ' NUMBER OF EACH THING
    Dim baguetteSize15Ordered As Integer = 0
    Dim baguetteSize30Ordered As Integer = 0

    Dim baguetteTypeWhiteOrdered As Integer = 0
    Dim baguetteTypeBrownOrdered As Integer = 0
    Dim baguetteTypeSeededOrdered As Integer = 0

    Dim baguetteFillingBeefOrdered As Integer = 0
    Dim baguetteFillingChickenOrdered As Integer = 0
    Dim baguetteFillingCheeseOrdered As Integer = 0
    Dim baguetteFillingEggOrdered As Integer = 0
    Dim baguetteFillingTunaOrdered As Integer = 0
    Dim baguetteFillingTurkeyOrdered As Integer = 0

    Function getYesNo(message As String) As Boolean
        Dim userResponse As String = ""
        While userResponse <> "yes" And userResponse <> "no"
            Console.Write(message)
            userResponse = Console.ReadLine().ToLower()
        End While

        Return userResponse = "yes"
    End Function

    Sub outputBaguette()
        Console.WriteLine("Baguette size: " & baguetteSize & "cm")
        Console.WriteLine("Bread type: " & breadType)
        Console.WriteLine("Bread filling: " & breadFilling)

        ' Output salads if the user chose them
        If breadSalad1 <> "" Then
            Console.WriteLine("First bread salad: " & breadSalad1)
        End If
        If breadSalad2 <> "" Then
            Console.WriteLine("Second bread salad: " & breadSalad2)
        End If
        If breadSalad3 <> "" Then
            Console.WriteLine("Third bread salad: " & breadSalad3)
        End If

    End Sub

    Sub getBaguetteSize()
        baguetteSize = 0
        While baguetteSize <> 15 And baguetteSize <> 30
            Console.Write("What size bread would you like in cm? (either 15cm or 30cm): ")
            Try
                baguetteSize = CInt(Console.ReadLine())
            Catch ex As Exception
                Console.WriteLine("Please only enter 15 or 30 for the bread size.")
            End Try
        End While
    End Sub

    Sub getBreadType()
        breadType = ""
        While breadType <> "White" And breadType <> "Brown" And breadType <> "Seeded"
            Console.Write("What bread type would you like? Either White, Brown or Seeded: ")
            breadType = Console.ReadLine()
        End While
    End Sub

    Sub getBaguetteFilling()
        breadFilling = ""
        While breadFilling <> "Beef" And breadFilling <> "Chicken" And breadFilling <> "Cheese" And breadFilling <> "Egg" And breadFilling <> "Tuna" And breadFilling <> "Turkey"
            Console.Write("What filling would you like for the baguette? Either Beef, Chicken, Cheese, Egg, Tuna or Turkey: ")
            breadFilling = Console.ReadLine()
        End While
    End Sub

    Sub getBaguetteSalads()
        breadSalad1 = ""
        breadSalad2 = ""
        breadSalad3 = ""
        Console.WriteLine("The salads available are Lettuce, Tomato, Sweetcorn, Cucumber, Peppers, or nothing. (Press enter for nothing).")

        While breadSalad1 <> "Lettuce" And breadSalad1 <> "Tomato" And breadSalad1 <> "Sweetcorn" And breadSalad1 <> "Cucumber" And breadSalad1 <> "Peppers"
            Console.WriteLine("What would you like for the first salad: ")
            breadSalad1 = Console.ReadLine()

            If breadSalad1 = "" Then
                Return
            End If
        End While


        While breadSalad2 <> "Lettuce" And breadSalad2 <> "Tomato" And breadSalad2 <> "Sweetcorn" And breadSalad2 <> "Cucumber" And breadSalad2 <> "Peppers"
            Console.WriteLine("What would you like for the second salad: ")
            breadSalad2 = Console.ReadLine()

            If breadSalad2 = "" Then
                Return
            End If
        End While


        While breadSalad3 <> "Lettuce" And breadSalad3 <> "Tomato" And breadSalad3 <> "Sweetcorn" And breadSalad3 <> "Cucumber" And breadSalad3 <> "Peppers"
            Console.WriteLine("What would you like for the third salad: ")
            breadSalad3 = Console.ReadLine()

            If breadSalad3 = "" Then
                Return
            End If
        End While
    End Sub

    Sub generateDailyReport()
        Console.Clear()
        Console.WriteLine("Total number of baguettes ordered today: " & currentOrderId & Environment.NewLine)
        Console.WriteLine("Bread sizes ordered:")
        Console.WriteLine(String.Format("15cm: {1}{0}30cm: {2}", Environment.NewLine, baguetteSize15Ordered, baguetteSize30Ordered))
        Console.WriteLine("Bread types ordered:")
        Console.WriteLine(String.Format("White bread: {1}{0}Brown bread: {2}{0}Seeded bread: {3}{0}", Environment.NewLine, baguetteTypeWhiteOrdered, baguetteTypeBrownOrdered, baguetteTypeSeededOrdered))
        Console.WriteLine("Bread fillings ordered:")
        Console.WriteLine(String.Format("Beef filling: {1}{0}Chicken filling: {2}{0}Cheese filling: {3}{0}Egg filling: {4}{0}Tuna filling: {5}{0}Turkey filling: {6}{0}", Environment.NewLine, baguetteFillingBeefOrdered, baguetteFillingChickenOrdered, baguetteFillingCheeseOrdered, baguetteFillingEggOrdered, baguetteFillingTunaOrdered, baguetteFillingTurkeyOrdered))

        ' Get least and most popular baguette fillings
        ' "Beef", "Chicken", "Cheese", "Egg", "Tuna", "Turkey"
        Dim leastPopularFillingAmount As Integer = baguetteFillingBeefOrdered
        Dim leastPopularFilling As String = "Beef"
        Dim mostPopularFillingAmount As Integer = baguetteFillingBeefOrdered
        Dim mostPopularFilling As String = "Beef"

        If baguetteFillingChickenOrdered < leastPopularFillingAmount Then
            leastPopularFilling = "Chicken"
            leastPopularFillingAmount = baguetteFillingChickenOrdered
        End If
        If baguetteFillingChickenOrdered > mostPopularFillingAmount Then
            mostPopularFilling = "Chicken"
            mostPopularFillingAmount = baguetteFillingChickenOrdered
        End If

        If baguetteFillingCheeseOrdered < leastPopularFillingAmount Then
            leastPopularFilling = "Cheese"
            leastPopularFillingAmount = baguetteFillingCheeseOrdered
        End If
        If baguetteFillingCheeseOrdered > mostPopularFillingAmount Then
            mostPopularFilling = "Cheese"
            mostPopularFillingAmount = baguetteFillingCheeseOrdered
        End If

        If baguetteFillingEggOrdered < leastPopularFillingAmount Then
            leastPopularFilling = "Egg"
            leastPopularFillingAmount = baguetteFillingEggOrdered
        End If
        If baguetteFillingEggOrdered > mostPopularFillingAmount Then
            mostPopularFilling = "Egg"
            mostPopularFillingAmount = baguetteFillingEggOrdered
        End If

        If baguetteFillingTunaOrdered < leastPopularFillingAmount Then
            leastPopularFilling = "Tuna"
            leastPopularFillingAmount = baguetteFillingTunaOrdered
        End If
        If baguetteFillingTunaOrdered > mostPopularFillingAmount Then
            mostPopularFilling = "Tuna"
            mostPopularFillingAmount = baguetteFillingTunaOrdered
        End If

        If baguetteFillingTurkeyOrdered < leastPopularFillingAmount Then
            leastPopularFilling = "Turkey"
            leastPopularFillingAmount = baguetteFillingTurkeyOrdered
        End If
        If baguetteFillingTurkeyOrdered > mostPopularFillingAmount Then
            mostPopularFilling = "Turkey"
            mostPopularFillingAmount = baguetteFillingTurkeyOrdered
        End If

        Dim totalOrdered = baguetteFillingBeefOrdered + baguetteFillingCheeseOrdered + baguetteFillingChickenOrdered + baguetteFillingEggOrdered + baguetteFillingTunaOrdered + baguetteFillingTurkeyOrdered
        Dim mostPopularPercentage = ((mostPopularFillingAmount / totalOrdered) * 100).ToString()
        Dim leastPopularPercentage = ((leastPopularFillingAmount / totalOrdered) * 100).ToString()
        ' BONUS POINT: check for IndexOf of a decimal point in the string, check IndexOf is not -1 and then make it Substring(string, 0, indexOf)
        If currentOrderId >= 1 Then
            ' There has been at least one order
            Console.WriteLine("Most popular filling was " & mostPopularFilling & " which was ordered " & mostPopularPercentage & "% of the time.")
            Console.WriteLine("Least popular filling was " & leastPopularFilling & " which was ordered " & leastPopularPercentage & "% of the time.")
        End If
    End Sub

    Sub createBaguette()
        Console.Clear()
        Console.WriteLine("Now creating a baguette.")
        getBaguetteSize()
        getBreadType()
        getBaguetteFilling()
        getBaguetteSalads()

        Dim shouldModify = True
        While shouldModify
            Console.Clear()
            outputBaguette()
            shouldModify = getYesNo("Would you like to modify your order? (yes/no): ")
            If shouldModify Then
                Dim shouldModifyBreadSize = getYesNo("Would you like to modify your bread size? (yes/no): ")
                If shouldModifyBreadSize Then
                    getBaguetteSize()
                End If

                Dim shouldModifyBreadType = getYesNo("Would you like to modify your bread type? (yes/no): ")
                If shouldModifyBreadType Then
                    getBreadType()
                End If

                Dim shouldModifyBreadFilling = getYesNo("Would you like to modify your bread filling? (yes/no): ")
                If shouldModifyBreadFilling Then
                    getBaguetteFilling()
                End If

                Dim shouldModifyBreadSalad = getYesNo("Would you like to modify your bread salads? (yes/no): ")
                If shouldModifyBreadSalad Then
                    getBaguetteSalads()
                End If
            End If
        End While

        Dim shouldContinue As String = getYesNo("Would you like to proceed with your order? (yes/no): ")
        If shouldContinue = False Then
            Return
        End If

        Console.Clear()
        outputBaguette()
        currentOrderId += 1
        Console.WriteLine("Your order number is " & currentOrderId)

        ' INCREMENT COUNTERS
        If baguetteSize = 15 Then
            baguetteSize15Ordered += 1
        ElseIf baguetteSize = 30 Then
            baguetteSize30Ordered += 1
        End If

        If breadType = "White" Then
            baguetteTypeWhiteOrdered += 1
        ElseIf breadType = "Brown" Then
            baguetteTypeBrownOrdered += 1
        ElseIf breadType = "Seeded" Then
            baguetteTypeSeededOrdered += 1
        End If

        If breadFilling = "Beef" Then
            baguetteFillingBeefOrdered += 1
        ElseIf breadFilling = "Chicken" Then
            baguetteFillingChickenOrdered += 1
        ElseIf breadFilling = "Cheese" Then
            baguetteFillingCheeseOrdered += 1
        ElseIf breadFilling = "Egg" Then
            baguetteFillingEggOrdered += 1
        ElseIf breadFilling = "Tuna" Then
            baguetteFillingTunaOrdered += 1
        ElseIf breadFilling = "Turkey" Then
            baguetteFillingTurkeyOrdered += 1
        End If
    End Sub

    Sub Main()
        While True
            Dim shouldMakeBaguette = getYesNo("Would you like to make a baguette? (yes/no): ")

            If shouldMakeBaguette Then
                createBaguette()
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey()
            End If

            generateDailyReport()
        End While
    End Sub

End Module
