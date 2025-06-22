import {lazy, FC, Suspense} from 'react'
import {Route, Routes, Navigate} from 'react-router-dom'
import {MasterLayout} from '../../_metronic/layout/MasterLayout'
import TopBarProgress from 'react-topbar-progress-indicator'
import {DashboardWrapper} from '../pages/dashboard/DashboardWrapper'
import {MenuTestPage} from '../pages/MenuTestPage'
import {getCSSVariableValue} from '../../_metronic/assets/ts/_utils'
import {WithChildren} from '../../_metronic/helpers'
import BuilderPageWrapper from '../pages/layout-builder/BuilderPageWrapper'
import OrderPage from '../pages/order/orderPage'
const PrivateRoutes = () => {
  const ProfilePage = lazy(() => import('../modules/profile/ProfilePage'))
  const AccountPage = lazy(() => import('../modules/accounts/AccountPage'))
  const ChatPage = lazy(() => import('../modules/apps/chat/ChatPage'))
  const UsersPage = lazy(() => import('../modules/apps/user-management/UsersPage'))
  const CustomerPage = lazy(() => import('../pages/customer/customerPage'))
  const CreateCustomer = lazy(() => import('../pages/customer/createCustomerPage'))
  const EmbellishMentTypePage = lazy(
    () => import('../pages/embellishment_type/embellishmentTypePage')
  )
  const CreateEmbellishMentTypePage = lazy(
    () => import('../pages/embellishment_type/createEmbellishmentTypePage')
  )
  const EmbellishMentPage = lazy(() => import('../pages/embellishment/embellishmentpage'))
  const CreateEmbellishmentPage = lazy(
    () => import('../pages/embellishment/createEmbellishmentPage')
  )
  const MeasurementPage = lazy(() => import('../pages/measurement/measurementPage'))
  const CreateMeasurementPage = lazy(() => import('../pages/measurement/createMeasurementPage'))
  const OrderPage = lazy(() => import('../pages/order/orderPage'))
  const CreateOrderPage = lazy(() => import('../pages/order/createOrderPage'))
  return (
    <Routes>
      <Route element={<MasterLayout />}>
        {/* Redirect to Dashboard after success login/registartion */}
        <Route path='auth/*' element={<Navigate to='/dashboard' />} />
        {/* Pages */}
        <Route path='dashboard' element={<DashboardWrapper />} />
        <Route path='builder' element={<BuilderPageWrapper />} />
        <Route path='menu-test' element={<MenuTestPage />} />
        <Route
          path='order'
          element={
            <SuspensedView>
              <OrderPage className='mb-5 mb-xl-8' />
            </SuspensedView>
          }
        />
        <Route
          path='order-create'
          element={
            <SuspensedView>
              <CreateOrderPage />
            </SuspensedView>
          }
        />
        <Route
          path='customer'
          element={
            <SuspensedView>
              <CustomerPage className='mb-5 mb-xl-8' />
            </SuspensedView>
          }
        />
        <Route
          path='measurement-create'
          element={
            <SuspensedView>
              <CreateMeasurementPage />
            </SuspensedView>
          }
        />
        <Route
          path='measurement'
          element={
            <SuspensedView>
              <MeasurementPage className='mb-5 mb-xl-8' />
            </SuspensedView>
          }
        />
        <Route
          path='customer-create'
          element={
            <SuspensedView>
              <CreateCustomer />
            </SuspensedView>
          }
        />
        <Route
          path='embellishmentType'
          element={
            <SuspensedView>
              <EmbellishMentTypePage className='mb-5 mb-xl-8' />
            </SuspensedView>
          }
        />

        <Route
          path='/embellishmentType-create'
          element={
            <SuspensedView>
              <CreateEmbellishMentTypePage />
            </SuspensedView>
          }
        />
        <Route
          path='embellishment'
          element={
            <SuspensedView>
              <EmbellishMentPage className='mb-5 mb-xl-8' />
            </SuspensedView>
          }
        />
        <Route
          path='embellishment-create'
          element={
            <SuspensedView>
              <CreateEmbellishmentPage />
            </SuspensedView>
          }
        />

        {/* Lazy Modules */}
        <Route
          path='crafted/pages/profile/*'
          element={
            <SuspensedView>
              <ProfilePage />
            </SuspensedView>
          }
        />
        <Route path='embellishment' element={<EmbellishMentPage className='mb-5 mb-xl-8' />} />
        <Route
          path='crafted/account/*'
          element={
            <SuspensedView>
              <AccountPage />
            </SuspensedView>
          }
        />
        <Route
          path='apps/chat/*'
          element={
            <SuspensedView>
              <ChatPage />
            </SuspensedView>
          }
        />
        <Route
          path='apps/user-management/*'
          element={
            <SuspensedView>
              <UsersPage />
            </SuspensedView>
          }
        />
        {/* Page Not Found */}
        <Route path='*' element={<Navigate to='/error/404' />} />
      </Route>
    </Routes>
  )
}

const SuspensedView: FC<WithChildren> = ({children}) => {
  const baseColor = getCSSVariableValue('--kt-primary')
  TopBarProgress.config({
    barColors: {
      '0': baseColor,
    },
    barThickness: 1,
    shadowBlur: 5,
  })
  return <Suspense fallback={<TopBarProgress />}>{children}</Suspense>
}

export {PrivateRoutes}
