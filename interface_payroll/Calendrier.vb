Public Class form_Calendrier
    Private Sub btn_calendrier_envoyer_Click(sender As Object, e As EventArgs) Handles btn_calendrier_envoyer.Click
        ' boucle pour comptabiliser les codes
        comptage_codes()
        remplissage()

    End Sub

    Private Sub Calendrier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' au chargement, l'année et le mois en cours sont chargés
        Me.txt_annee.Text = Format(Now, "yyyy")
        Me.cmb_mois.Text = Format(Now, "MMMM")

        determination_jour()
        'remplissage()

        ' pour que les textes des lbl se mettent à jour dès le chargement
        Me.btn_calendrier_executer.PerformClick()

    End Sub
    ' --------------------------------------------------------- DEBUT FONCTIONS -------------------------------------

    ''' <summary>
    ''' 
    ''' </summary>
    Sub determination_jour()
        Dim jour1 As String = Me.lbl_jour1.Text
        Dim fevrier As Integer
        ' pour créer une variable de type admissible en paramètre de isBissextile()
        Dim annee = New DateTime(Me.txt_annee.Text, 1, 1)
        If Isbissextile(annee) Then
            fevrier = 29
        Else
            fevrier = 28
        End If
        ' cacher les dates excédentes
        Select Case Me.cmb_mois.Text
            Case "Janvier"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Février"
                If fevrier = 29 Then
                    'jour 31
                    Me.Label32.Visible = False
                    Me.lbl_jour31.Visible = False
                    Me.TextBox31.Visible = False
                    Me.txt_code_31.Visible = False
                    'jour 30
                    Me.Label28.Visible = False
                    Me.lbl_jour30.Visible = False
                    Me.TextBox30.Visible = False
                    Me.txt_code_30.Visible = False
                Else
                    ' jour 31
                    Me.Label32.Visible = False
                    Me.lbl_jour31.Visible = False
                    Me.TextBox31.Visible = False
                    Me.txt_code_31.Visible = False
                    ' jour 30
                    Me.Label28.Visible = False
                    Me.lbl_jour30.Visible = False
                    Me.TextBox30.Visible = False
                    Me.txt_code_30.Visible = False
                    ' jour 29
                    Me.Label24.Visible = False
                    Me.lbl_jour29.Visible = False
                    Me.TextBox29.Visible = False
                    Me.txt_code_29.Visible = False
                End If
            Case "Mars"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Avril"
                ' jour 31
                Me.Label32.Visible = False
                Me.lbl_jour31.Visible = False
                Me.TextBox31.Visible = False
                Me.txt_code_31.Visible = False
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Mai"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Juin"
                ' jour 31
                Me.Label32.Visible = False
                Me.lbl_jour31.Visible = False
                Me.TextBox31.Visible = False
                Me.txt_code_31.Visible = False
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Juillet"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Août"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Septembre"
                ' jour 31
                Me.Label32.Visible = False
                Me.lbl_jour31.Visible = False
                Me.TextBox31.Visible = False
                Me.txt_code_31.Visible = False
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Octobre"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Novembre"
                ' jour 31
                Me.Label32.Visible = False
                Me.lbl_jour31.Visible = False
                Me.TextBox31.Visible = False
                Me.txt_code_31.Visible = False
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case "Décembre"
                ' jour 31
                Me.Label32.Visible = True
                Me.lbl_jour31.Visible = True
                Me.TextBox31.Visible = True
                Me.txt_code_31.Visible = True
                ' jour 30
                Me.Label28.Visible = True
                Me.lbl_jour30.Visible = True
                Me.TextBox30.Visible = True
                Me.txt_code_30.Visible = True
                ' jour 29
                Me.Label24.Visible = True
                Me.lbl_jour29.Visible = True
                Me.TextBox29.Visible = True
                Me.txt_code_29.Visible = True
            Case Else
                MsgBox("determination_jour error")
        End Select

    End Sub

    ''' <summary>
    ''' Fonction de calcul qui détermine si l'année est bissextile ou non
    ''' </summary>
    ''' <param name="maDate"></param>
    ''' <returns></returns>
    Function Isbissextile(maDate As Date) As Boolean
        If Year(maDate) Mod 4 = 0 And (Year(maDate) Mod 100 <> 0 Or Year(maDate) Mod 400 = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Convertit le mois en chiffre
    ''' </summary>
    ''' <param name="mois">Le paramètre proviendra de la combobox des mois de l'année: "Dim date1 As New Date(annee, mois, 1)"</param>
    ''' <returns>Renvoie un INT pour créer une date</returns>
    Function conversion_mois(mois) As Integer
        Select Case mois
            Case "Janvier"
                Return 1
            Case "Février"
                Return 2
            Case "Mars"
                Return 3
            Case "Avril"
                Return 4
            Case "Mai"
                Return 5
            Case "Juin"
                Return 6
            Case "Juillet"
                Return 7
            Case "Août"
                Return 8
            Case "Septembre"
                Return 9
            Case "Octobre"
                Return 10
            Case "Novembre"
                Return 11
            Case "Décembre"
                Return 12
            Case Else
                MsgBox("erreur combo mois")
                Return 0
        End Select
    End Function
    ' --------------------------------------------------------------------- FIN FONCTIONS ----------------------------------


    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_calendrier_executer.Click
        ' ces lignes calculent le jour de la semaine qui correspond à la date du mois sélectionné et de l'année sélectionnée
        ' afin de remplir le calendrier
        Dim annee As Integer = Me.txt_annee.Text
        Dim mois As Integer = conversion_mois(Me.cmb_mois.Text)
        Dim date1 As New Date(annee, mois, 1)
        Me.lbl_jour1.Text = Format(date1, "ddd")
        Dim date2 As New Date(annee, mois, 2)
        Me.lbl_jour2.Text = Format(date2, "ddd")
        Dim date3 As New Date(annee, mois, 3)
        Me.lbl_jour3.Text = Format(date3, "ddd")
        Dim date4 As New Date(annee, mois, 4)
        Me.lbl_jour4.Text = Format(date4, "ddd")
        Dim date5 As New Date(annee, mois, 5)
        Me.lbl_jour5.Text = Format(date5, "ddd")
        Dim date6 As New Date(annee, mois, 6)
        Me.lbl_jour6.Text = Format(date6, "ddd")
        Dim date7 As New Date(annee, mois, 7)
        Me.lbl_jour7.Text = Format(date7, "ddd")
        Dim date8 As New Date(annee, mois, 8)
        Me.lbl_jour8.Text = Format(date8, "ddd")
        Dim date9 As New Date(annee, mois, 9)
        Me.lbl_jour9.Text = Format(date9, "ddd")
        Dim date10 As New Date(annee, mois, 10)
        Me.lbl_jour10.Text = Format(date10, "ddd")
        Dim date11 As New Date(annee, mois, 11)
        Me.lbl_jour11.Text = Format(date11, "ddd")
        Dim date12 As New Date(annee, mois, 12)
        Me.lbl_jour12.Text = Format(date12, "ddd")
        Dim date13 As New Date(annee, mois, 13)
        Me.lbl_jour13.Text = Format(date13, "ddd")
        Dim date14 As New Date(annee, mois, 14)
        Me.lbl_jour14.Text = Format(date14, "ddd")
        Dim date15 As New Date(annee, mois, 15)
        Me.lbl_jour15.Text = Format(date15, "ddd")
        Dim date16 As New Date(annee, mois, 16)
        Me.lbl_jour16.Text = Format(date16, "ddd")
        Dim date17 As New Date(annee, mois, 17)
        Me.lbl_jour17.Text = Format(date17, "ddd")
        Dim date18 As New Date(annee, mois, 18)
        Me.lbl_jour18.Text = Format(date18, "ddd")
        Dim date19 As New Date(annee, mois, 19)
        Me.lbl_jour19.Text = Format(date19, "ddd")
        Dim date20 As New Date(annee, mois, 20)
        Me.lbl_jour20.Text = Format(date20, "ddd")
        Dim date21 As New Date(annee, mois, 21)
        Me.lbl_jour21.Text = Format(date21, "ddd")
        Dim date22 As New Date(annee, mois, 22)
        Me.lbl_jour22.Text = Format(date22, "ddd")
        Dim date23 As New Date(annee, mois, 23)
        Me.lbl_jour23.Text = Format(date23, "ddd")
        Dim date24 As New Date(annee, mois, 24)
        Me.lbl_jour24.Text = Format(date24, "ddd")
        Dim date25 As New Date(annee, mois, 25)
        Me.lbl_jour25.Text = Format(date25, "ddd")
        Dim date26 As New Date(annee, mois, 26)
        Me.lbl_jour26.Text = Format(date26, "ddd")
        Dim date27 As New Date(annee, mois, 27)
        Me.lbl_jour27.Text = Format(date27, "ddd")
        Dim date28 As New Date(annee, mois, 28)
        Me.lbl_jour28.Text = Format(date28, "ddd")
        If (Isbissextile(date1) And mois = 2) Or mois = 1 Or (mois >= 3 And mois <= 12) Then
            Dim date29 As New Date(annee, mois, 29)
            Me.lbl_jour29.Text = Format(date29, "ddd")
        End If

        If (mois <> 2) Then
            Dim date30 As New Date(annee, mois, 30)
            Me.lbl_jour30.Text = Format(date30, "ddd")
        End If

        If (mois = 1 Or mois = 3 Or mois = 5 Or mois = 7 Or mois = 8 Or mois = 10 Or mois = 12) Then
            Dim date31 As New Date(annee, mois, 31)
            Me.lbl_jour31.Text = Format(date31, "ddd")
        End If
        ' -------------------------------------- fin complétion calendrier auto -----------------------------------------------------------------
        determination_jour()
        remplissage()

    End Sub


    ''' <summary>
    ''' Fonction qui permet de remplir la partie "régime hebdo" de la grille des prestations, suivant la grille prévue dans la fiche signalétique
    ''' Fonction qui va compter le nombre de jours ouvrables du mois
    ''' </summary>
    Sub remplissage()
        Dim LabelArray() As Label = {lbl_jour1, lbl_jour2, lbl_jour3, lbl_jour4, lbl_jour5, lbl_jour6, lbl_jour7, lbl_jour8, lbl_jour9, lbl_jour10, lbl_jour11, lbl_jour12, lbl_jour13, lbl_jour14, lbl_jour15, lbl_jour16, lbl_jour17, lbl_jour18, lbl_jour19, lbl_jour20, lbl_jour21, lbl_jour22, lbl_jour23, lbl_jour24, lbl_jour25, lbl_jour26, lbl_jour27, lbl_jour28, lbl_jour29, lbl_jour30, lbl_jour31}
        Dim nbr_jours_ouvrables As Integer = 0
        Dim nbr_hrs_prestables_D As Integer = 0
        For i = 1 To 31
            Dim lblTxt As String = GroupBox2.Controls("lbl_jour" & i).Text
            Select Case lblTxt
                Case "lun."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_lundi.Text
                    ' Je compte les .visible sinon le comptage ira toujours jusque 31
                    If GroupBox2.Controls("textBox" & i).Visible = True Then
                        nbr_jours_ouvrables += 1
                        'nbr_hrs_prestables_D += GroupBox2.Controls("TextBox" & i).Text
                        nbr_hrs_prestables_D += 8

                    End If

                Case "mar."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_mardi.Text
                    If GroupBox2.Controls("textBox" & i).Visible = True Then
                        nbr_jours_ouvrables += 1
                        'nbr_hrs_prestables_D += GroupBox2.Controls("TextBox" & i).Text
                        nbr_hrs_prestables_D += 8

                    End If
                Case "mer."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_mercredi.Text
                    If GroupBox2.Controls("textBox" & i).Visible = True Then
                        nbr_jours_ouvrables += 1
                        'nbr_hrs_prestables_D += GroupBox2.Controls("TextBox" & i).Text
                        nbr_hrs_prestables_D += 8

                    End If
                Case "jeu."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_jeudi.Text
                    If GroupBox2.Controls("textBox" & i).Visible = True Then
                        nbr_jours_ouvrables += 1
                        'nbr_hrs_prestables_D += GroupBox2.Controls("TextBox" & i).Text
                        nbr_hrs_prestables_D += 8

                    End If
                Case "ven."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_vendredi.Text
                    If GroupBox2.Controls("textBox" & i).Visible = True Then
                        nbr_jours_ouvrables += 1
                        'nbr_hrs_prestables_D += GroupBox2.Controls("TextBox" & i).Text
                        nbr_hrs_prestables_D += 6

                    End If
                Case "sam."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_samedi.Text
                Case "dim."
                    GroupBox2.Controls("TextBox" & i).Text = form_payroll.txt_regime_dimanche.Text
                Case Else
                    'MsgBox("Remplissage()")
            End Select
        Next
        form_payroll.lbl_nbr_jrs_prestables_D.Text = nbr_jours_ouvrables
        form_payroll.lbl_nbre_heures_prestees_et_assimilees.Text = CDbl(form_payroll.lbl_nbr_heures_prestees.Text) + CDbl(form_payroll.lbl_nbr_heures_feries.Text)
        form_payroll.lbl_hrs_prestables_U.Text = nbr_hrs_prestables_D

    End Sub


    ''' <summary>
    ''' Fonction qui compte le nombre d'occurence de chaque code et le nombre d'heures correspondant
    ''' </summary>
    Sub comptage_codes()
        Dim textArray() As TextBox = {txt_code_1, txt_code_2, txt_code_3, txt_code_4, txt_code_5, txt_code_6, txt_code_7, txt_code_8, txt_code_9, txt_code_10, txt_code_11, txt_code_12, txt_code_13, txt_code_14, txt_code_15, txt_code_16, txt_code_17, txt_code_18, txt_code_19, txt_code_20, txt_code_21, txt_code_22, txt_code_23, txt_code_24, txt_code_25, txt_code_26, txt_code_27, txt_code_28, txt_code_29, txt_code_30, txt_code_31}
        Dim nbr_heures_prestees_P As Integer = 0
        Dim nbr_heures_feries_F As Integer = 0
        Dim nbr_jours_F As Integer = 0
        Dim nbr_jours_P As Integer = 0
        For i = 1 To 31
            Dim code As String = GroupBox2.Controls("txt_code_" & i).Text
            Select Case code
                Case "p"
                    nbr_heures_prestees_P += GroupBox2.Controls("TextBox" & i).Text
                    nbr_jours_P += 1
                Case "f"
                    nbr_jours_F += 1
                    nbr_heures_feries_F += GroupBox2.Controls("TextBox" & i).Text
                Case Else
                    'MsgBox("comptage")
            End Select
        Next
        form_payroll.lbl_nbr_heures_prestees.Text = nbr_heures_prestees_P
        form_payroll.lbl_nbr_jours_P.Text = nbr_jours_P
        form_payroll.lbl_nbre_jours_feries.Text = nbr_jours_F
        form_payroll.lbl_nbre_jours_prestes_et_assimiles_J.Text = nbr_jours_F + nbr_jours_P
        form_payroll.lbl_nbr_heures_feries.Text = nbr_heures_feries_F
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class